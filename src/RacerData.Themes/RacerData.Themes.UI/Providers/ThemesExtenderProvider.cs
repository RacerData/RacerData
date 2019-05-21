using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Windows.Forms;

namespace RacerData.Themes.UI.Providers
{
    [ProvideProperty("Themes", typeof(Control))]
    [DesignerSerializer(typeof(ThemesSerializer<Themes>), typeof(CodeDomSerializer))]
    class ThemesExtenderProvider : Component, IExtenderProvider
    {
        #region fields

        Dictionary<Control, string[]> constants;

        #endregion

        #region ctor

        public ThemesExtenderProvider()
        {
            this.constants = new Dictionary<Control, string[]>();
        }

        #endregion

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        #endregion

        #region Constants Get and Set

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(ThemesEditor<Themes>), typeof(UITypeEditor))]
        public string[] GetThemes(Control control)
        {
            string[] constantsForControl;

            if (this.constants.TryGetValue(control, out constantsForControl))
            {
                return constantsForControl;
            }
            else
            {
                return null;
            }
        }

        public void SetThemes(Control control, string[] constantsForControl)
        {
            this.constants[control] = constantsForControl;
        }

        #endregion
    }
}