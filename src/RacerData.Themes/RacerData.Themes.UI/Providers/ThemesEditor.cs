using System;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RacerData.Themes.UI.Providers
{
    class ThemesEditor<T> : UITypeEditor
    {
        private IWindowsFormsEditorService svc;
        private ListBox listBox;

        public ThemesEditor()
        {
            this.listBox = new ListBox();
            this.listBox.BorderStyle = BorderStyle.None;
            this.listBox.SelectionMode = SelectionMode.MultiExtended;
        }

        private void listBox_Click(object sender, EventArgs e)
        {
            this.svc.CloseDropDown();
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            this.listBox.Items.Clear();

            string[] currentConstants = value as string[];

            foreach (FieldInfo constantFieldInfo in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string constant = constantFieldInfo.Name;

                this.listBox.Items.Add(constant);

                if (currentConstants != null && Array.Exists<string>(currentConstants, delegate (string currentConstant) { return currentConstant == constant; }))
                {
                    this.listBox.SelectedItems.Add(constant);
                }
            }

            this.svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (this.svc != null)
            {
                this.svc.DropDownControl(this.listBox);

                string[] newConstants = new string[this.listBox.SelectedIndices.Count];

                for (int i = 0; i < newConstants.Length; ++i)
                {
                    newConstants[i] = this.listBox.SelectedItems[i].ToString();
                }

                return newConstants;
            }

            return value;
        }

    }
}
