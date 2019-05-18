using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class AboutDialog : Form
    {
        #region fields

        private List<AssemblyReference> _references = new List<AssemblyReference>();

        #endregion

        #region ctor

        public AboutDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void DisplayAppInformation()
        {
            lblTitle.Text = @"r/NASCAR Timing & Scoring";

            var version = Assembly.GetEntryAssembly().GetName().Version;
            lblVersion.Text = $"Version: {version}";

            lblCompany.Text = "Copyright (c) RacerData Software 2019 - MIT License";
        }

        protected virtual List<AssemblyReference> ReadAssemblyInformation()
        {
            var references = new List<AssemblyReference>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
                AssemblyName asmName = asm.GetName();
                string name = asmName.Name;
                Version asmV = asmName.Version;
                string fileV = fvi.FileVersion;
                string prodV = fvi.ProductVersion;

                var lvi = new AssemblyReference()
                {
                    Name = name,
                    Version = asmV.ToString(),
                    FileVersion = fileV,
                    ProductVersion = prodV
                };

                references.Add(lvi);
            }

            return references;
        }

        protected virtual void DisplayAssemblyInformation(List<AssemblyReference> references)
        {
            var buildDate = DateTime.Parse(Properties.Resources.BuildDate);
            lblBuildDate.Text = $"Build Date: {buildDate.ToString()}";

            lvReferences.Items.Clear();

            foreach (AssemblyReference reference in references.OrderBy(r => r.Name))
            {
                lvReferences.Items.Add(new ListViewItem(
                    new string[] {
                          reference.Name,
                          reference.Version,
                          reference.FileVersion,
                          reference.ProductVersion }));
            }
        }

        protected virtual void CopyToClipboard(List<AssemblyReference> references)
        {
            var maxNameLength = references.Max(r => r.Name.Length);
            var maxVersionLength = Math.Max(references.Max(r => r.Version.Length), "Assembly Version".Length);
            var maxFileVersionLength = references.Max(r => r.FileVersion.Length);
            var maxProductVersionLength = references.Max(r => r.ProductVersion.Length);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Application Name: {lblTitle.Text}");
            sb.AppendLine(lblVersion.Text);
            sb.AppendLine($"Company: {lblCompany.Text}");
            sb.AppendLine(lblBuildDate.Text);
            sb.AppendLine();
            sb.AppendLine("Referenced Assemblies");
            sb.AppendLine();

            List<string[]> lines = new List<string[]>();
            lines.Add(new List<string>() {
                    "Assembly Name",
                    "Assembly Version",
                    "Product Version",
                    "File Version"}.ToArray());

            lines.Add(new List<string>() {
                    new string('-',maxNameLength),
                    new string('-',maxVersionLength),
                    new string('-',maxFileVersionLength),
                    new string('-',maxProductVersionLength)}.ToArray());

            foreach (AssemblyReference reference in references.OrderBy(r => r.Name))
            {
                lines.Add(new List<string>() {
                    reference.Name,
                    reference.Version,
                    reference.FileVersion,
                    reference.ProductVersion}.ToArray());
            }

            var output = ConsoleUtility.PadElementsInLines(lines, 3);

            sb.AppendLine(output);

            sb.AppendLine();
            sb.AppendLine($"Report Generated on {DateTime.Now.ToString()} from {Environment.MachineName}");
            sb.AppendLine();

            Clipboard.SetText(sb.ToString());
        }

        #endregion

        #region private

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            DisplayAppInformation();

            _references = ReadAssemblyInformation();

            DisplayAssemblyInformation(_references);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(_references);

            MessageBox.Show(this,
                        "Report copied to clipboard",
                        "Report Copied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }

        #endregion

        #region classes

        protected class AssemblyReference
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public string ProductVersion { get; set; }
            public string FileVersion { get; set; }
        }

        private static class ConsoleUtility
        {
            /// <summary>
            /// Converts a List of string arrays to a string where each element in each line is correctly padded.
            /// Make sure that each array contains the same amount of elements!
            /// - Example without:
            /// Title Name Street
            /// Mr. Roman Sesamstreet
            /// Mrs. Claudia Abbey Road
            /// - Example with:
            /// Title   Name      Street
            /// Mr.     Roman     Sesamstreet
            /// Mrs.    Claudia   Abbey Road
            /// <param name="lines">List lines, where each line is an array of elements for that line.</param>
            /// <param name="padding">Additional padding between each element (default = 1)</param>
            /// </summary>
            public static string PadElementsInLines(List<string[]> lines, int padding = 1)
            {
                // Calculate maximum numbers for each element accross all lines
                var numElements = lines[0].Length;
                var maxValues = new int[numElements];
                for (int i = 0; i < numElements; i++)
                {
                    maxValues[i] = lines.Max(x => x[i].Length) + padding;
                }
                var sb = new StringBuilder();
                // Build the output
                bool isFirst = true;
                foreach (var line in lines)
                {
                    if (!isFirst)
                    {
                        sb.AppendLine();
                    }
                    isFirst = false;
                    for (int i = 0; i < line.Length; i++)
                    {
                        var value = line[i];
                        // Append the value with padding of the maximum length of any value for this element
                        sb.Append(value.PadRight(maxValues[i]));
                    }
                }
                return sb.ToString();
            }
        }
        #endregion
    }
}