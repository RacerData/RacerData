﻿using System;
using System.ComponentModel;
using RacerData.Data.Ports;
using RacerData.Themes.Ports;

namespace RacerData.Themes.Models
{
    public class ThemeDefinition : IKeyedItem<Guid>, INotifyPropertyChanged, ITheme
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region properties

        private Guid _key;
        public Guid Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private Appearance _appearance = StandardAppearances.SystemAppearance;
        public Appearance Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                OnPropertyChanged(nameof(Appearance));
            }
        }

        #endregion

        #region ctor

        public ThemeDefinition()
        {

        }

        #endregion
    }
}