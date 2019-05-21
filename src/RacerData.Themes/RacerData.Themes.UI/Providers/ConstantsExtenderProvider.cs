using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Windows.Forms;

namespace RacerData.Themes.UI.Providers
{
    [ProvideProperty("Constants", typeof(Control))]
    [DesignerSerializer(typeof(ConstantsSerializer<Constants>), typeof(CodeDomSerializer))]
    class ConstantsExtenderProvider : Component, IExtenderProvider
    {
        #region Private Fields

        Dictionary<Control, string[]> constants;

        #endregion

        #region

        public ConstantsExtenderProvider()
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
        [Editor(typeof(ConstantsEditor<Constants>), typeof(UITypeEditor))]
        public string[] GetConstants(Control control)
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

        public void SetConstants(Control control, string[] constantsForControl)
        {
            this.constants[control] = constantsForControl;
        }

        #endregion
    }
}
