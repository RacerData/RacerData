using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RacerData.Themes.TestApp.Providers
{
    class ThemeNameEditor : UITypeEditor
    {
        private IWindowsFormsEditorService svc;
        private ListBox listBox;

        public ThemeNameEditor()
        {
            this.listBox = new ListBox();
            this.listBox.BorderStyle = BorderStyle.None;
            this.listBox.SelectionMode = SelectionMode.One;
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

            string currentConstant = (string)value;

            var itemList = new List<String>();

            itemList.Add("None");
            itemList.Add("System");
            itemList.Add("Blue");
            itemList.Add("Black");

            foreach (string item in itemList)
            {
                this.listBox.Items.Add(item);

                if (!String.IsNullOrEmpty(currentConstant) && item == currentConstant)
                {
                    this.listBox.SelectedItem = item;
                }
            }

            this.svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (this.svc != null)
            {
                this.svc.DropDownControl(this.listBox);

                string newConstants = "";

                if (this.listBox.SelectedItem != null)
                {
                    newConstants = this.listBox.SelectedItem.ToString();
                }

                return newConstants;
            }

            return "FOO BABY";
        }

    }
}
