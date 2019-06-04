using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class WeekendScheduleItem : UserControl
    {
        private bool _isActive = false;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                DisplayModel(_model);
            }
        }
        private EventScheduleModel _model;
        public EventScheduleModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                DisplayModel(_model);
            }
        }

        public WeekendScheduleItem(EventScheduleModel model)
            : this()
        {
            Model = model;
        }

        public WeekendScheduleItem()
        {
            InitializeComponent();
        }

        private void WeekendScheduleItem_Load(object sender, EventArgs e)
        {
            DisplayModel(Model);
        }

        protected virtual void DisplayModel(EventScheduleModel model)
        {
            picLogo.Image = DownloadImageFromWeb(Model.LogoUrl);
            lblDateTime.Text = Model.DateTime.ToString("h:mm tt");
            lblEvent.Text = Model.Title;

            if (DateTime.Now > Model.DateTime && !IsActive)
            {
                this.BackColor = Color.Gainsboro;
                picLogo.BackColor = Color.Gainsboro;
                lblDateTime.BackColor = Color.Gainsboro;
                lblEvent.BackColor = Color.Gainsboro;

                lblDateTime.ForeColor = Color.Gray;
                lblEvent.ForeColor = Color.Gray;
            }
            else if (IsActive)
            {
                this.BackColor = Color.Gold;
                picLogo.BackColor = Color.Gold;
                lblDateTime.BackColor = Color.Gold;
                lblEvent.BackColor = Color.Gold;

                lblDateTime.ForeColor = Color.Black;
                lblEvent.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.White;
                picLogo.BackColor = Color.White;
                lblDateTime.BackColor = Color.White;
                lblEvent.BackColor = Color.White;

                lblDateTime.ForeColor = Color.Black;
                lblEvent.ForeColor = Color.Black;
            }
        }

        protected virtual Bitmap DownloadImageFromWeb(string imageUrl)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(imageUrl);
            System.Net.WebResponse resp = request.GetResponse();
            System.IO.Stream respStream = resp.GetResponseStream();
            Bitmap bmp = new Bitmap(respStream);
            respStream.Dispose();

            return bmp;
        }

    }
}
