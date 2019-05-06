﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.rNascarApp.Models
{
    public class ViewDataSource
    {
        public string Name { get; set; }
        public string Path { get; set; }
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
        public string Type { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public IList<ViewDataSource> Lists { get; set; } = new List<ViewDataSource>();
        public IList<ViewDataSource> NestedClasses { get; set; } = new List<ViewDataSource>();
        public IList<ViewDataMember> Fields { get; set; } = new List<ViewDataMember>();

    }
}
