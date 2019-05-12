using System.ComponentModel;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public class CreateViewContext : INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        private ViewDataSource _viewDataSource = null;
        public ViewDataSource ViewDataSource
        {
            get
            {
                return _viewDataSource;
            }
            set
            {
                _viewDataSource = value;
                OnPropertyChanged(nameof(ViewDataSource));
            }
        }

        private BindingList<ViewDataMember> _viewDataMembers;
        public BindingList<ViewDataMember> ViewDataMembers
        {
            get
            {
                return _viewDataMembers;
            }
            set
            {
                _viewDataMembers = value;
                OnPropertyChanged(nameof(ViewDataMembers));
            }
        }

        private BindingList<ListColumn> _viewListColumns;
        public BindingList<ListColumn> ViewListColumns
        {
            get
            {
                return _viewListColumns;
            }
            set
            {
                _viewListColumns = value;
                OnPropertyChanged(nameof(ViewListColumns));
            }
        }

        #endregion

        #region ctor

        public CreateViewContext()
        {
            _viewDataMembers = new BindingList<ViewDataMember>();
            _viewDataSource = new ViewDataSource();
            _viewListColumns = new BindingList<ListColumn>();

            PropertyChanged += CreateViewContext_PropertyChanged;
        }

        #endregion

        #region public

        private void CreateViewContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ViewDataSource")
            {
                ViewDataMembers = new BindingList<ViewDataMember>();
                ViewListColumns = new BindingList<ListColumn>();
            }
            else if (e.PropertyName == "ViewDataMembers")
            {
                ViewListColumns = new BindingList<ListColumn>();
            }
            else if (e.PropertyName == "ViewListColumns")
            {

            }
        }

        #endregion
    }
}
