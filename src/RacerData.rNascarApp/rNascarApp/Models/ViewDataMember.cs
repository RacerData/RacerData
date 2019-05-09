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
        public string DataFeedTypeAssemblyQualifiedName { get; set; }
        public string DataFeedTypeFullName { get; set; }
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
                        else if (char.IsNumber(Name[i]))
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
        public string AssemblyQualifiedName { get; set; }
        public string Type { get; set; }
        private string _convertedType = String.Empty;
        public string ConvertedType
        {
            get
            {
                if (String.IsNullOrEmpty(_convertedType))
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
            return Path.GetHashCode();
        }

        public bool Equals(ViewDataMember other)
        {
            return other != null && Path == other.Path;
        }

        #endregion
    }
}
