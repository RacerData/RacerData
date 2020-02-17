using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Models;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class SetupView : UserControl, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        private SetupModel _setup1;
        public SetupModel Setup1
        {
            get
            {
                return _setup1;
            }
            set
            {
                _setup1 = value;
                OnPropertyChanged(nameof(Setup1));
            }
        }

        private SetupModel _setup2;
        public SetupModel Setup2
        {
            get
            {
                return _setup2;
            }
            set
            {
                _setup2 = value;
                OnPropertyChanged(nameof(Setup2));
            }
        }

        private SetupModel _setupDiff;
        public SetupModel SetupDiff
        {
            get
            {
                return _setupDiff;
            }
            set
            {
                _setupDiff = value;
                OnPropertyChanged(nameof(SetupDiff));
            }
        }

        #endregion

        #region ctor

        public SetupView()
        {
            InitializeComponent();

            this.PropertyChanged += SetupView_PropertyChanged;
        }

        #endregion

        #region public

        public void ClearDisplay()
        {
            lblSetupName1.Text = "";
            lblSetupName2.Text = "";
            txtChangeLog.Clear();

            frontView.ClearDisplay();
            leftFrontView.ClearDisplay();
            rightFrontView.ClearDisplay();
            leftRearView.ClearDisplay();
            rightRearView.ClearDisplay();
            rearView.ClearDisplay();
        }

        #endregion

        #region protected

        protected virtual void SetupView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(Setup1))
            {
                ClearDisplay();

                _setup2 = null;
                _setupDiff = null;

                DisplaySetup1(Setup1);
            }
            else if (e.PropertyName == nameof(Setup2))
            {
                _setupDiff = null;

                DisplaySetup2(Setup2);
            }
            else if (e.PropertyName == nameof(SetupDiff))
            {
                DisplaySetupDiff(SetupDiff);
            }
        }

        protected virtual void DisplaySetup1(SetupModel setup)
        {
            if (setup == null)
                return;

            lblSetupName1.Text = setup.Description;

            frontView.Setup1 = setup.Front;
            leftFrontView.Setup1 = setup.LeftFront;
            rightFrontView.Setup1 = setup.RightFront;
            leftRearView.Setup1 = setup.LeftRear;
            rightRearView.Setup1 = setup.RightRear;
            rearView.Setup1 = setup.Rear;
        }
        protected virtual void DisplaySetup2(SetupModel setup)
        {
            if (setup == null)
                return;

            lblSetupName2.Text = setup.Description;

            frontView.Setup2 = setup.Front;
            leftFrontView.Setup2 = setup.LeftFront;
            rightFrontView.Setup2 = setup.RightFront;
            leftRearView.Setup2 = setup.LeftRear;
            rightRearView.Setup2 = setup.RightRear;
            rearView.Setup2 = setup.Rear;
        }
        protected virtual void DisplaySetupDiff(SetupModel setupDiff)
        {
            if (setupDiff == null)
                return;

            frontView.SetupDiff = setupDiff.Front;
            leftFrontView.SetupDiff = setupDiff.LeftFront;
            rightFrontView.SetupDiff = setupDiff.RightFront;
            leftRearView.SetupDiff = setupDiff.LeftRear;
            rightRearView.SetupDiff = setupDiff.RightRear;
            rearView.SetupDiff = setupDiff.Rear;

            EvaluateChanges(setupDiff);
        }
        protected virtual string EvaluateChange(string position, string setting, double diffValue)
        {
            if (diffValue != 0)
                return $"{position,-8}: {setting,-12} {diffValue}\r\n";
            else
                return string.Empty;
        }

        protected virtual string EvaluateChange(string position, string setting, double diffValue, IList<double> affectedBy)
        {
            if (diffValue != 0 && affectedBy.Max() == 0)
                return $"{position,-8}: {setting,-12} {diffValue}\r\n";
            else
                return string.Empty;
        }
        protected virtual string EvaluateChanges(SetupModel setupDiffModel)
        {
            StringBuilder sb = new StringBuilder();

            var springAndCollarChanges = new List<double>()
                {
                    setupDiffModel.LeftFront.Collar,
                    setupDiffModel.LeftFront.Spring,
                    setupDiffModel.RightFront.Collar,
                    setupDiffModel.RightFront.Spring,
                    setupDiffModel.LeftRear.Collar,
                    setupDiffModel.LeftRear.Spring,
                    setupDiffModel.RightRear.Collar,
                    setupDiffModel.RightRear.Spring
                };
            var camberCasterChanges = new List<double>()
                {
                    setupDiffModel.LeftFront.Camber,
                    setupDiffModel.LeftFront.Caster,
                    setupDiffModel.RightFront.Camber,
                    setupDiffModel.RightFront.Caster
                };

            if ((springAndCollarChanges.Max() > 0 || camberCasterChanges.Max() > 0) && (setupDiffModel.Front.Front != 0 || setupDiffModel.Front.Cross != 0))
            {
                sb.Append("===============\r\n");
                sb.Append($"Front: {setupDiffModel.Front.Front}%\r\n");
                sb.Append($"Cross: {setupDiffModel.Front.Cross}%\r\n");
                sb.Append($"{setupDiffModel.LeftFront.Weight,3} | {setupDiffModel.RightFront.Weight,3}\r\n");
                sb.Append($"{setupDiffModel.LeftRear.Weight,3} | {setupDiffModel.RightRear.Weight,3}\r\n");
                sb.Append("===============\r\n");
            }

            // first order changes (No other changes affects these values)
            /*
            - Front
            Ballast Position
            Sway Bar Diameter
            Ft. Stagger
            Brake Bias
            
            - Front Corner
            Psi
            Shock Collar Offset
            Shock Rebound
            Spring

            - Rear Corner
            Psi
            Shock Collar Offset
            Shock Rebound
            Spring
            Track Bar Height

            - Rear
            Gear
            Fuel
            Stagger
            */
            string position = "Front";
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Front.Ballast), setupDiffModel.Front.Ballast));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Front.SwayBar), setupDiffModel.Front.SwayBar));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Front.Stagger), setupDiffModel.Front.Stagger));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Front.BrakeBias), setupDiffModel.Front.BrakeBias));

            position = "L Front";
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftFront.Psi), setupDiffModel.LeftFront.Psi));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftFront.Collar), setupDiffModel.LeftFront.Collar));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftFront.Rebound), setupDiffModel.LeftFront.Rebound));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftFront.Spring), setupDiffModel.LeftFront.Spring));

            position = "R Front";
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightFront.Psi), setupDiffModel.RightFront.Psi));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightFront.Collar), setupDiffModel.RightFront.Collar));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightFront.Rebound), setupDiffModel.RightFront.Rebound));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightFront.Spring), setupDiffModel.RightFront.Spring));

            position = "L Rear";
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftRear.Psi), setupDiffModel.LeftRear.Psi));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftRear.Collar), setupDiffModel.LeftRear.Collar));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftRear.Rebound), setupDiffModel.LeftRear.Rebound));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftRear.Spring), setupDiffModel.LeftRear.Spring));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.LeftRear.TrackBar), setupDiffModel.LeftRear.TrackBar));

            position = "R Rear";
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightRear.Psi), setupDiffModel.RightRear.Psi));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightRear.Collar), setupDiffModel.RightRear.Collar));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightRear.Rebound), setupDiffModel.RightRear.Rebound));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightRear.Spring), setupDiffModel.RightRear.Spring));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.RightRear.TrackBar), setupDiffModel.LeftRear.TrackBar));

            position = "Rear";
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Rear.Stagger), setupDiffModel.Rear.Stagger));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Rear.Gear), setupDiffModel.Rear.Gear));
            sb.Append(EvaluateChange(position, nameof(setupDiffModel.Rear.Fuel), setupDiffModel.Rear.Fuel));

            // second order changes (Other changes can affect these values)
            /*
            - Front
            Toe-In
                - Affected By
                    Spring
                    Shock Collar Offset
                    
            Sway Bar Preload
                - Affected By
                    Spring
                    Shock Collar Offset
            
            - Front Corner
            Ride Height
                - Affected By
                    Psi
                    Ballast Position
                    Spring
                    Shock Collar Offset
            Camber
                - Affected By
                    Psi
                    Ballast Position
                    Spring
                    Shock Collar Offset
            Caster
                - Affected By
                    Psi
                    Ballast Position
                    Spring
                    Shock Collar Offset

            - Rear Corner
            Ride Height
                - Affected By
                    Psi
                    Ballast Position
                    Spring
                    Shock Collar Offset

            - Rear

            */

            position = "Front";
            sb.Append(EvaluateChange(
                position,
                nameof(setupDiffModel.Front.Toe),
                setupDiffModel.Front.Toe,
                springAndCollarChanges));

            sb.Append(EvaluateChange(
                position,
                nameof(setupDiffModel.Front.SwayBar),
                setupDiffModel.Front.SwayBar,
                springAndCollarChanges));

            position = "L Front";
            sb.Append(EvaluateChange(
                position,
                nameof(setupDiffModel.LeftFront.Camber),
                setupDiffModel.LeftFront.Camber,
                springAndCollarChanges));

            sb.Append(EvaluateChange(
               position,
               nameof(setupDiffModel.LeftFront.Caster),
               setupDiffModel.LeftFront.Caster,
               springAndCollarChanges));

            position = "R Front";
            sb.Append(EvaluateChange(
                position,
                nameof(setupDiffModel.RightFront.Camber),
                setupDiffModel.RightFront.Camber,
                springAndCollarChanges));

            sb.Append(EvaluateChange(
               position,
               nameof(setupDiffModel.RightFront.Caster),
               setupDiffModel.RightFront.Caster,
               springAndCollarChanges));

            // third order changes (Can only change these values by other changes)
            /*
            - Front
            Front Weight Percent
            Cross Weight Percent
            
            - Front Corner
            Corner Weight

            - Rear Corner
            Corner Weight

            - Rear

            */
            var changeLog = sb.ToString();
            txtChangeLog.Text = changeLog;
            return changeLog;
        }

        #endregion
    }
}
