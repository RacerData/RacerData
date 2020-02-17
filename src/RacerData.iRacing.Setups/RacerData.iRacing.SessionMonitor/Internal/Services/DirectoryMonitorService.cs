using System;
using System.IO;
using RacerData.iRacing.SessionMonitor.Internal.Models;

namespace RacerData.iRacing.SessionMonitor.Internal.Services
{
    internal abstract class DirectoryMonitorService : IDisposable, IDirectoryMonitorService
    {
        #region events

        public event EventHandler<DirectoryMonitorEventArgs> FileCreated;
        protected virtual void OnFileCreated(string fileName)
        {
            FileCreated?.Invoke(this, new DirectoryMonitorEventArgs()
            {
                FileName = fileName,
                EventType = DirectoryMonitorEventType.Created
            });
        }

        public event EventHandler<DirectoryMonitorEventArgs> FileUpdated;
        protected virtual void OnFileUpdated(string fileName)
        {
            FileUpdated?.Invoke(this, new DirectoryMonitorEventArgs()
            {
                FileName = fileName,
                EventType = DirectoryMonitorEventType.Updated
            });
        }

        public event EventHandler<ErrorEventArgs> FileServiceError;
        protected virtual void OnFileServiceError(ErrorEventArgs error)
        {
            FileServiceError?.Invoke(this, error);
        }

        #endregion

        #region fields

        private bool _debug = true;
        private object _fswLock = new object();
        private FileSystemWatcher _fsw = null;
        private string _lastCreated;
        private DateTime _lastCreatedWriteTime = DateTime.Now;
        private DateTime _lastChangedWriteTime = DateTime.Now;

        #endregion

        #region properties

        private string _path;
        public virtual string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                MonitorPropertyChanged();
            }
        }

        private string _filter = "*.*";
        public virtual string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                MonitorPropertyChanged();
            }
        }

        private bool _includeSubdirectories = true;
        public virtual bool IncludeSubdirectories
        {
            get
            {
                return _includeSubdirectories;
            }
            set
            {
                _includeSubdirectories = value;
                MonitorPropertyChanged();
            }
        }

        #endregion

        #region ctor

        protected DirectoryMonitorService()
            : this(null, null)
        {

        }

        protected DirectoryMonitorService(string path)
            : this(path, null)
        {

        }

        protected DirectoryMonitorService(string path, string filter)
        {
            Path = path;
            Filter = filter;

            _fsw = new FileSystemWatcher()
            {
                EnableRaisingEvents = false
            };

            _fsw.Changed += _fsw_Changed;
            _fsw.Created += _fsw_Created;
            _fsw.Error += _fsw_Error;
        }

        #endregion

        #region public

        public virtual void StartService()
        {
            InitializeWatcher();

            _fsw.EnableRaisingEvents = true;

            if (_debug) Console.WriteLine($"Starting directory monitor service. Path: {Path}; Filter: {Filter}");

        }

        public virtual void StopService()
        {
            if (_fsw != null)
            {
                _fsw.EnableRaisingEvents = false;
            }
        }

        public void Dispose()
        {
            ((IDisposable)_fsw).Dispose();
        }

        #endregion

        #region protected

        protected virtual void MonitorPropertyChanged()
        {
            if (_fsw != null && _fsw.EnableRaisingEvents == true)
            {
                InitializeWatcher();

                _fsw.EnableRaisingEvents = true;
            }
        }

        protected virtual void InitializeWatcher()
        {
            if (_fsw == null)
                _fsw = new FileSystemWatcher();
            else if (_fsw.EnableRaisingEvents)
                _fsw.EnableRaisingEvents = false;

            _fsw.Path = Path;
            _fsw.Filter = String.IsNullOrEmpty(Filter) ? "*.*" : Filter;
            _fsw.IncludeSubdirectories = IncludeSubdirectories;
        }

        protected virtual void _fsw_Created(object sender, FileSystemEventArgs e)
        {
            lock (_fswLock)
            {
                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                if (lastWriteTime.Ticks != _lastCreatedWriteTime.Ticks)
                {
                    if (_debug) Console.WriteLine($"File Created: {e.Name} {lastWriteTime.Ticks} {_lastCreatedWriteTime.Ticks}");
                    OnFileCreated(e.FullPath);
                    _lastCreatedWriteTime = lastWriteTime;
                    _lastCreated = e.Name;
                }
            }
        }

        protected virtual void _fsw_Changed(object sender, FileSystemEventArgs e)
        {
            lock (_fswLock)
            {

                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                if (_lastCreated == e.Name && DateTime.Now.Subtract(_lastCreatedWriteTime).Seconds < 3)
                {
                    return;
                }

                if (lastWriteTime.Ticks != _lastChangedWriteTime.Ticks)
                {
                    if (_debug) Console.WriteLine($"File Changed: {e.Name} {lastWriteTime.Ticks} {_lastChangedWriteTime.Ticks}");
                    OnFileUpdated(e.FullPath);
                    _lastChangedWriteTime = lastWriteTime;
                }
            }
        }

        private void _fsw_Error(object sender, ErrorEventArgs e)
        {
            OnFileServiceError(e);
        }

        #endregion
    }
}
