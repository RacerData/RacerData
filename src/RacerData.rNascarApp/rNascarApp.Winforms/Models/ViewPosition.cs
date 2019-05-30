﻿namespace rNascarApp.UI.Models
{
    public class ViewPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private int _rowSpan = 1;
        public int RowSpan
        {
            get
            {
                return _rowSpan;
            }
            set
            {
                _rowSpan = value > 0 ? value : 1;
            }
        }
        private int _columnSpan = 1;
        public int ColumnSpan
        {
            get
            {
                return _columnSpan;
            }
            set
            {
                _columnSpan = value > 0 ? value : 1;
            }
        }

        public override string ToString()
        {
            return $"{Row}:{Column}-{RowSpan}:{ColumnSpan}";
        }
    }
}