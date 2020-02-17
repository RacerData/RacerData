using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;
using RacerData.Logging.Ports;

namespace RacerData.iRacingTelemetry.TestApp
{
    public partial class TelemetryFileInfoView : Form
    {
        #region fields

        int? total = null;
        int? unprocessed = null;
        int pageSize = 100;
        int pageIndex = 0;

        #endregion

        #region properties

        public ILoggerService Logger { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        private int TotalRecordSetCount
        {
            get
            {
                return chkUnprocessed.Checked ? unprocessed.Value : total.Value;
            }
        }
        private int PageCount
        {
            get
            {
                if (unprocessed == null || total == null)
                {
                    return 0;
                }

                var pageCount = (int)((Single)TotalRecordSetCount / (Single)pageSize);

                return pageCount;
            }
        }

        #endregion

        #region ctor/load

        public TelemetryFileInfoView(IServiceProvider serviceProvider, ILoggerService logger)
            : this()
        {
            ServiceProvider = serviceProvider;
            Logger = logger;
        }

        public TelemetryFileInfoView()
        {
            InitializeComponent();
        }

        private void TelemetryFileInfoView_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTelemetryFileInfos.DataBindingComplete += MakeColumnsSortable_DataBindingComplete;

                UpdateTelemetryFileInfoDisplayList();

                txtPageSize.Text = pageSize.ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region private
        private void ExceptionHandler(Exception ex)
        {
            ExceptionHandler(ex, "Exception in TelemetryFileInfoView");
        }
        private void ExceptionHandler(Exception ex, string message)
        {
            ExceptionHandler(ex, message, false);
        }
        private void ExceptionHandler(Exception ex, string message, bool suppressMessageBox)
        {
            if (Logger != null)
                Logger.LogException(ex, message);

            Console.WriteLine(ex.ToString());
            MessageWriteLine(ex.ToString());

            if (!suppressMessageBox)
                MessageBox.Show(ex.Message);
        }

        private void MessageWriteLine()
        {
            MessageWriteLine("\r\n");
        }
        private void MessageWriteLine(string message)
        {
            txtMessages.AppendText($"{message}\r\n");
        }
        protected virtual string GetMessages(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ex.Message);
            var inner = ex;

            while (inner.InnerException != null)
            {
                inner = inner.InnerException;
                sb.AppendLine(inner.Message);
            }

            return sb.ToString();
        }

        private void UpdateTelemetryFileInfoCounts()
        {
            using (ITelemetryFileInfoRepository telemetryInfoRepository = ServiceProvider.GetRequiredService<ITelemetryFileInfoRepository>())
            {
                unprocessed = telemetryInfoRepository.GetUnprocessedTelemetryFileInfosCountAsync();
                total = telemetryInfoRepository.GetTelemetryFileInfosCountAsync();
            }

            UpdatePageCountDisplays();
        }
        private void UpdatePageCountDisplays()
        {
            lblPage.Text = $"Page {pageIndex + 1} of {PageCount}";
            var currentPageCount = ((pageIndex * pageSize) + pageSize);
            if (currentPageCount > TotalRecordSetCount)
                currentPageCount = TotalRecordSetCount;
            lblFileInfoStatus.Text = $"TelemetryFileInfo: {unprocessed} records unprocessed out of {total} total  ({((pageIndex * pageSize) + 1)}-{currentPageCount} of {TotalRecordSetCount})";

        }

        private void UpdateTelemetryFileInfoDisplayList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UpdateTelemetryFileInfoCounts();

                var fileInfos = LoadTelemetryFileInfoList();

                DisplayTelemetryFileInfoList(fileInfos);

                UpdatePageCountDisplays();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private IQueryable<TelemetryFileInfo> LoadTelemetryFileInfoList()
        {
            btnFirst.Enabled = (pageIndex != 0);
            btnPrevious.Enabled = (pageIndex > 0);
            btnNext.Enabled = (pageIndex < PageCount);
            btnLast.Enabled = (pageIndex != PageCount);

            ITelemetryFileInfoRepository telemetryInfoRepository = ServiceProvider.GetRequiredService<ITelemetryFileInfoRepository>();

            var query = telemetryInfoRepository.GetTelemetryFileInfoQuery();

            if (chkUnprocessed.Checked)
                query = query.Where(f => f.IsProcessed == false);

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            return query;
        }

        private void DisplayTelemetryFileInfoList(IQueryable<TelemetryFileInfo> telemetryFileInfos)
        {
            try
            {
                SortableBindingList<TelemetryFileInfo> dataList = new SortableBindingList<TelemetryFileInfo>(telemetryFileInfos.ToList());

                dgvTelemetryFileInfos.DataSource = dataList;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        void MakeColumnsSortable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Add this as an event on DataBindingComplete
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null)
            {
                var ex = new InvalidOperationException("This event is for a DataGridView type senders only.");
                ex.Data.Add("Sender type", sender.GetType().Name);
                throw ex;
            }

            foreach (DataGridViewColumn column in dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private async Task ProcessSelectedAsync()
        {
            IList<TelemetryFileInfo> selected = new List<TelemetryFileInfo>();

            foreach (DataGridViewRow row in this.dgvTelemetryFileInfos.SelectedRows)
            {
                TelemetryFileInfo fileInfo = row.DataBoundItem as TelemetryFileInfo;

                selected.Add(fileInfo);
            }

            await ProcessTelemetryFileInfosAsync(selected);

            UpdateTelemetryFileInfoDisplayList();
        }
        private async Task ProcessTelemetryFileInfosAsync(IList<TelemetryFileInfo> fileList)
        {
            try
            {
                ITelemetryFileInfoRepository telemetryInfoRepository = ServiceProvider.GetRequiredService<ITelemetryFileInfoRepository>();

                MessageWriteLine($"Processing {fileList.Count} files...");

                int idx = 0;

                foreach (TelemetryFileInfo telemetryFileInfo in fileList.OrderBy(t => t.Timestamp))
                {
                    try
                    {
                        MessageWriteLine($"{DateTime.Now.ToString()} Processing file {++idx} of {fileList.Count} - [{telemetryFileInfo.Name}]");

                        using (var scope = ServiceProvider.CreateScope())
                        {
                            ISessionService sessionService = scope.ServiceProvider.GetRequiredService<ISessionService>();

                            await sessionService.ImportTelemetry(telemetryFileInfo);

                            telemetryInfoRepository.MarkAsProcessed(telemetryFileInfo.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler(ex, $"{telemetryFileInfo.Name} -> {ex.ToString()}", true);

                        telemetryInfoRepository.MarkAsErrored(telemetryFileInfo.Id, ex);
                    }
                }

                UpdateTelemetryFileInfoCounts();

                MessageWriteLine("Done!");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region private [EventHandlers]

        private void dgvTelemetryFileInfos_SelectionChanged(object sender, EventArgs e)
        {
            btnProcess.Enabled = dgvTelemetryFileInfos.SelectedRows.Count > 0;
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                await ProcessSelectedAsync();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                ExceptionHandler(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void chkUnprocessed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateTelemetryFileInfoDisplayList();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pageIndex = 0;
            UpdateTelemetryFileInfoDisplayList();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageIndex > 0)
            {
                pageIndex -= 1;
                UpdateTelemetryFileInfoDisplayList();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (PageCount > pageIndex)
            {
                pageIndex += 1;
                UpdateTelemetryFileInfoDisplayList();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {

            pageIndex = PageCount;
            UpdateTelemetryFileInfoDisplayList();
        }

        private void txtPageSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int buffer = -1;
                if (int.TryParse(txtPageSize.Text, out buffer))
                {
                    pageSize = buffer;
                    UpdateTelemetryFileInfoDisplayList();
                }
            }
        }

        #endregion
    }
}
