using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RacerData.iRacing.Setups.Models.SkModified;
using RacerData.iRacing.Setups.Modifieds;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Setups.ClassBuilder
{
    public partial class Form1 : Form
    {
        private const string TelemetryDirectory = @"C:\Users\Rob\Documents\iRacing\telemetry";

        private IList<ModifiedSetup> _setups = new List<ModifiedSetup>();
        public IList<ModifiedSetup> Setups
        {
            get
            {
                return _setups;
            }
            set
            {
                _setups = value;
                DisplaySetupList(_setups);
            }
        }

        //IbtTelemetryFile _telemetryFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private void DisplaySetupList(IList<ModifiedSetup> setups)
        {
            lstSetups.DataSource = null;

            lstSetups.DisplayMember = "Name";
            lstSetups.DataSource = setups;
        }

        private void lstSetups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModifiedSetup setup = lstSetups.SelectedItem as ModifiedSetup;

            SetupSelected(setup);
        }

        private void SetupSelected(ModifiedSetup setup)
        {
            lblTelemetryFileName.Text = "";
            lblUpdateCount.Text = "";

            if (setup != null)
            {
                lblTelemetryFileName.Text = Path.GetFileName(setup.SetupFileName);

                lblUpdateCount.Text = setup.UpdateCount.ToString();
            }
        }

        private async Task<ModifiedSetup> ReadSetupFileAsync()
        {
            ModifiedSetup setup = null;

            try
            {
                string telemetryFileName = SelectTelemetryFile();

                if (!String.IsNullOrEmpty(telemetryFileName))
                {
                    setup = await ReadSkModifiedSetupAsync(telemetryFileName);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return setup;
        }

        private async Task<IList<ModifiedSetup>> ReadSetupFolderAsync()
        {
            IList<ModifiedSetup> setups = new List<ModifiedSetup>();

            try
            {
                string telemetryFolderName = SelectTelemetryFolder();

                if (!String.IsNullOrEmpty(telemetryFolderName))
                {
                    foreach (var telemetryFileName in Directory.GetFiles(telemetryFolderName, "*.ibt"))
                    {
                        ModifiedSetup setup = await ReadSkModifiedSetupAsync(telemetryFileName);

                        setups.Add(setup);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return setups;
        }

        private async Task<ModifiedSetup> ReadSkModifiedSetupAsync(string telemetryFileName)
        {
            //string telemetryFileContent = File.ReadAllText(telemetryFileName);

            //IIbtFileParser _telemetryFileParser = new IbtFileParser(new IbtFileReader(), new IbtSessionParser());

            //var ibtFile = await _telemetryFileParser.ParseTelemetryFileAsync(telemetryFileName, IbtParseOptions.All);

            //_telemetryFile = ibtFile;

            //string setupYaml = ibtFile.SessionData.SessionInfo.CarSetupYaml;

            //string setupJson = ConvertYamlToJson(setupYaml);

            //ModifiedSetup setup = DeserializeSetupJson(setupJson);

            //setup.SetupFileName = Path.GetFileNameWithoutExtension(telemetryFileName);

            //setup.Track = ibtFile.SessionData.SessionInfo.weekendInfo["TrackDisplayShortName"].ToString();

            //setup.TelemetryFileName = telemetryFileName;

            //return setup;
        }

        private string SelectTelemetryFile()
        {
            string telemetryFile = null;

            try
            {
                var dialog = new OpenFileDialog()
                {
                    InitialDirectory = TelemetryDirectory,
                    Filter = "iRacing Telemetry Files (*.ibt)|*.ibt|All Files |*.*",
                    FilterIndex = 0,
                    Multiselect = false
                };

                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    telemetryFile = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return telemetryFile;
        }

        private string SelectTelemetryFolder()
        {
            string telemetryFolder = null;

            try
            {
                var dialog = new FolderBrowserDialog()
                {
                    SelectedPath = TelemetryDirectory
                };

                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    telemetryFolder = dialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return telemetryFolder;
        }

        private string ConvertYamlToJson(string setupYaml)
        {
            string setupJson = null;

            try
            {
                var reader = new StringReader(setupYaml);
                var deserializer = new Deserializer();
                var yamlObject = deserializer.Deserialize(reader);

                var writer = new StringWriter();
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, yamlObject);

                setupJson = writer.ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return setupJson;
        }

        private ModifiedSetup DeserializeSetupJson(string setupJson)
        {
            ModifiedSetup setup = null;

            try
            {
                var rootObject = JsonConvert.DeserializeObject<RootObject>(setupJson);

                setup = rootObject.CarSetup;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return setup;
        }

        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            var setup = await ReadSetupFileAsync();

            Setups = new List<ModifiedSetup>() { setup };
        }

        private async void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            Setups = await ReadSetupFolderAsync();
        }

        private void btnSessionInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var sessionData = _telemetryFile.SessionData.SessionInfo.SessionValues();

                txtSessionData.Text = sessionData + "\r\n";

                var weekendData = _telemetryFile.SessionData.SessionInfo.WeekendValues();

                txtSessionData.Text += weekendData;

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnTireSheet_Click(object sender, EventArgs e)
        {
            try
            {
                var tireSheetDialog = new TireSheet2();

                var setup = Setups.FirstOrDefault();

                var skSetup = new SkModified(setup);

                tireSheetDialog.tiresBindingSource.DataSource = skSetup.Tires;

                tireSheetDialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}
