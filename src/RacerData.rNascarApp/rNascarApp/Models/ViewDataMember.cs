using System;
using System.Text;

namespace RacerData.rNascarApp.Models
{
    public class ViewDataMember : IEquatable<ViewDataMember>
    {
        #region properties

        public string Name { get; set; }
        public string Path { get; set; }
        public string DataFeed { get; set; }
        string _caption = String.Empty;
        public string Caption
        {
            get
            {
                if (String.IsNullOrEmpty(_caption))
                {
                    StringBuilder sb = new StringBuilder();
                    // Leave the first letter capitalized without a space
                    sb.Append(Name[0].ToString());
                    // Leave the second letter capitalized without a space for 'LF', 'LR', etc)
                    sb.Append(Name[1].ToString());

                    for (int i = 2; i < Name.ToCharArray().Length; i++)
                    {
                        if (char.IsUpper(Name[i]))
                        {
                            sb.Append(" ");
                        }
                        else if (char.IsNumber(Name[i]) && !char.IsNumber(Name[i - 1]))
                        {
                            sb.Append(" ");
                        }

                        sb.Append(Name[i].ToString());
                    }

                    _caption = sb.ToString();
                }

                return _caption;
            }
            set
            {
                _caption = value;
            }
        }
        public Type Type { get; set; }
        public Type DataFeedType { get; set; }
        private Type _convertedType = null;
        public Type ConvertedType
        {
            get
            {
                if (_convertedType == null)
                    _convertedType = Type;

                return _convertedType;
            }
            set
            {
                _convertedType = value;
            }
        }

        #endregion

        #region public

        public override int GetHashCode()
        {
            return DataFeed.GetHashCode() + Path.GetHashCode();
        }

        public bool Equals(ViewDataMember other)
        {
            return other != null && DataFeed == other.DataFeed && Path == other.Path;
        }

        #endregion
    }
}
