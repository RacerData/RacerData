using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class SplashForm : Form
    {
        public enum SplashTypeOfMessage
        {
            Success,
            Warning,
            Error
        }

        delegate void CloseSplashHandler(SplashTypeOfMessage typeOfMessage, string message, bool itWasRinvoked);
        delegate void SplashMessageHandler(string message, bool itWasRinvoked);

        static SplashForm _splashForm = null;
        static Thread _splashThread = null;
        public static object locker = new object();
        public static bool WaitPlease = true;

        internal SplashForm()
        {
            InitializeComponent();
            lblLoading.Text = "Firing it up!";
        }

        public static void ShowSplashScreen()
        {
            if (_splashForm != null)
                return;
            _splashThread = new Thread(new ThreadStart(SplashForm.ShowSplash));
            _splashThread.IsBackground = true;
            _splashThread.SetApartmentState(ApartmentState.STA);
            _splashThread.Start();
        }

        public static void ShowSplash()
        {
            if (_splashForm == null)
            {
                _splashForm = new SplashForm();

            }
            _splashForm.TopMost = true;
            _splashForm.Show();
            lock (SplashForm.locker)
            {
                WaitPlease = false;
            }

            Application.Run(_splashForm);

        }

        public static void CloseSplash(SplashTypeOfMessage typeOfMessage, string message, bool itWasRinvoked)
        {
            CloseSplashHandler closeSpalshHandler = new CloseSplashHandler(CloseSplash);
            bool launched = false;
            while (!launched && !itWasRinvoked)
            {
                lock (SplashForm.locker)
                {
                    if (!SplashForm.WaitPlease)
                    {
                        launched = true;
                    }
                }
            }

            if (_splashForm != null && _splashThread != null)
            {
                if (_splashForm.InvokeRequired)
                {
                    _splashForm.Invoke(closeSpalshHandler, new object[] { typeOfMessage, message, true });
                }
                else
                {
                    switch (typeOfMessage)
                    {
                        case SplashTypeOfMessage.Warning:
                            break;
                        case SplashTypeOfMessage.Error:
                            MessageBox.Show("Error");
                            break;
                        default:
                            break;
                    }
                    _splashForm.Close();
                    _splashThread = null;
                }
            }
        }

        public static void SplashMessage(string message)
        {
            SplashMessage(message, false);
        }
        public static void SplashMessage(string message, bool itWasRinvoked)
        {
            SplashMessageHandler splashMessageHandler = new SplashMessageHandler(SplashMessage);

            if (_splashForm != null && _splashThread != null)
            {
                if (_splashForm.InvokeRequired)
                {
                    _splashForm.Invoke(splashMessageHandler, new object[] { message, true });
                }
                else
                {
                    _splashForm.lblLoading.Text = message;
                }
            }
        }
    }
}
