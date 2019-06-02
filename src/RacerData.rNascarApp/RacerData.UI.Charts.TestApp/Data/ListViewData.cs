namespace rNascarApp.UI.Data
{
    public class ListViewData
    {
        public string[,] DataValues { get; set; }

        public ListViewData(int rowCount, int columnCount)
        {
            DataValues = new string[rowCount, columnCount];
        }
    }
}
