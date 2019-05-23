using System.ComponentModel;
using System.Drawing;
using RacerData.Themes.Ports;

namespace RacerData.Themes.Models
{
    public class Appearance : INotifyPropertyChanged, IAppearance
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        private FontInfo _heading1FontInfo;
        public FontInfo Heading1FontInfo
        {
            get
            {
                return _heading1FontInfo;
            }
            set
            {
                _heading1FontInfo = value;
                OnPropertyChanged(nameof(Heading1FontInfo));
            }
        }

        private FontInfo _captionFontInfo;
        public FontInfo CaptionFontInfo
        {
            get
            {
                return _captionFontInfo;
            }
            set
            {
                _captionFontInfo = value;
                OnPropertyChanged(nameof(CaptionFontInfo));
            }
        }

        private FontInfo _rowItemFontInfo;
        public FontInfo RowItemFontInfo
        {
            get
            {
                return _rowItemFontInfo;
            }
            set
            {
                _rowItemFontInfo = value;
                OnPropertyChanged(nameof(RowItemFontInfo));
            }
        }

        private Color _foreColor;
        public virtual Color ForeColor
        {
            get
            {
                return _foreColor;
            }
            set
            {
                _foreColor = value;
                OnPropertyChanged(nameof(ForeColor));
            }
        }

        private Color _backColor;
        public virtual Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                OnPropertyChanged(nameof(BackColor));
            }
        }

        private Color _foreColor2;
        public virtual Color ForeColor2
        {
            get
            {
                return _foreColor2;
            }
            set
            {
                _foreColor2 = value;
                OnPropertyChanged(nameof(ForeColor2));
            }
        }

        private Color _backColor2;
        public virtual Color BackColor2
        {
            get
            {
                return _backColor2;
            }
            set
            {
                _backColor2 = value;
                OnPropertyChanged(nameof(BackColor2));
            }
        }

        private Color _selectedForeColor;
        public virtual Color SelectedForeColor
        {
            get
            {
                return _selectedForeColor;
            }
            set
            {
                _selectedForeColor = value;
                OnPropertyChanged(nameof(SelectedForeColor));
            }
        }

        private Color _selectedBackColor;
        public virtual Color SelectedBackColor
        {
            get
            {
                return _selectedBackColor;
            }
            set
            {
                _selectedBackColor = value;
                OnPropertyChanged(nameof(SelectedBackColor));
            }
        }

        private Color _mouseOverForeColor;
        public virtual Color MouseOverForeColor
        {
            get
            {
                return _mouseOverForeColor;
            }
            set
            {
                _mouseOverForeColor = value;
                OnPropertyChanged(nameof(MouseOverForeColor));
            }
        }

        private Color _mouseOverBackColor;
        public virtual Color MouseOverBackColor
        {
            get
            {
                return _mouseOverBackColor;
            }
            set
            {
                _mouseOverBackColor = value;
                OnPropertyChanged(nameof(MouseOverBackColor));
            }
        }

        private Color _borderColor = Color.Black;
        public virtual Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        private int _borderThickness = 1;
        public virtual int BorderThickness
        {
            get
            {
                return _borderThickness;
            }
            set
            {
                _borderThickness = value;
                OnPropertyChanged(nameof(BorderThickness));
            }
        }

        private FontInfo _fontInfo = new FontInfo() { Name = "Arial", Size = 9 };
        public FontInfo FontInfo
        {
            get
            {
                return _fontInfo;
            }
            set
            {
                _fontInfo = value;
                OnPropertyChanged(nameof(FontInfo));
            }
        }

        #endregion

        #region ctor

        public Appearance()
        {

        }

        #endregion
    }
}
