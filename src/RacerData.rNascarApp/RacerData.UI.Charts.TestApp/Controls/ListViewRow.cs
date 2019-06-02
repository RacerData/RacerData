namespace RacerData.WinForms.Controls
{
    public partial class ListViewRow : DraggableContainer
    {
        #region properties

        public bool IsColumnCaptions { get; set; }
        public int DisplayIndex { get; set; }
        
        #endregion

        #region ctor

        public ListViewRow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
