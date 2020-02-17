using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ui.SetupGrid;
using RacerData.iRacing.Sessions.Ui.ViewModels;
using static RacerData.iRacing.Sessions.Ui.ViewModels.SetupGridViewModel;

namespace RacerData.iRacingTelemetry.TestApp
{
    public partial class UiTest : Form
    {
        public IList<SetupValue> SetupValues { get; set; }
        public IList<SetupValue> PreviousSetupValues { get; set; }

        public UiTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            setupView1.ViewModel = new SetupGridViewModel()
            {
                PreviousSetupName = "bar",
                SetupName = "foo",
                SetupSections = new List<SetupSectionViewModel>()
                    {
                        new SetupSectionViewModel()
                        {
                            DisplayIndex=0,
                            SectionName = "Chassis.Front",
                            SetupValues = new List<SetupValueViewModel>()
                            {
                                new SetupValueViewModel()
                                {
                                DisplayIndex=0,
                                Property="SwayBarSize",
                                Value = "2.0",
                                PreviousValue="1.5",
                                Delta = ".5"
                                },
                                new SetupValueViewModel()
                                {
                                DisplayIndex=1,
                                Property="Toe In",
                                Value = "-1/16",
                                PreviousValue="-1/16"
                                }
                            }
                        },
                        new SetupSectionViewModel()
                        {
                            DisplayIndex=1,
                            SectionName = "Chassis.LeftFront",
                            SetupValues = new List<SetupValueViewModel>()
                            {
                                new SetupValueViewModel()
                                {
                                DisplayIndex=0,
                                Property="Spring",
                                Value = "400",
                                PreviousValue="425",
                                Delta = "-25"
                                },
                                new SetupValueViewModel()
                                {
                                DisplayIndex=1,
                                Property="Ride Height",
                                Value = "4",
                                PreviousValue="4 1/14",
                                Delta = "-1/4"
                                }
                            }
                        },
                        new SetupSectionViewModel()
                        {
                            DisplayIndex=1,
                            SectionName = "Chassis.RightFront",
                            SetupValues = new List<SetupValueViewModel>()
                            {
                                new SetupValueViewModel()
                                {
                                DisplayIndex=0,
                                Property="Spring",
                                Value = "550",
                                PreviousValue="525",
                                Delta = "25"
                                },
                                new SetupValueViewModel()
                                {
                                DisplayIndex=1,
                                Property="Ride Height",
                                Value = "4.5",
                                PreviousValue="4.5"
                                }
                            }
                        },
                        new SetupSectionViewModel()
                        {
                            DisplayIndex=1,
                            SectionName = "Chassis.LeftRear",
                            SetupValues = new List<SetupValueViewModel>()
                            {
                                new SetupValueViewModel()
                                {
                                DisplayIndex=0,
                                Property="Spring",
                                Value = "200",
                                PreviousValue="225",
                                Delta = "-25"
                                },
                                new SetupValueViewModel()
                                {
                                DisplayIndex=1,
                                Property="Ride Height",
                                Value = "4.75",
                                PreviousValue="4.5",
                                Delta = ".25"
                                }
                            }
                        },
                        new SetupSectionViewModel()
                        {
                            DisplayIndex=1,
                            SectionName = "Chassis.RightRear",
                            SetupValues = new List<SetupValueViewModel>()
                            {
                                new SetupValueViewModel()
                                {
                                DisplayIndex=0,
                                Property="Spring",
                                Value = "200",
                                PreviousValue="225",
                                Delta = "-25"
                                },
                                new SetupValueViewModel()
                                {
                                DisplayIndex=1,
                                Property="Ride Height",
                                Value = "5",
                                PreviousValue="5"
                                }
                            }
                        },
                        new SetupSectionViewModel()
                        {
                            DisplayIndex=1,
                            SectionName = "Chassis.Rear",
                            SetupValues = new List<SetupValueViewModel>()
                            {
                                new SetupValueViewModel()
                                {
                                DisplayIndex=0,
                                Property="Gear",
                                Value = "4.56",
                                PreviousValue="4.56"
                                },
                                new SetupValueViewModel()
                                {
                                DisplayIndex=1,
                                Property="Fuel",
                                Value = "5.2",
                                PreviousValue="4.1",
                                Delta = "1.1"
                                }
                            }
                        }
                    }
            };
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        private void UiTest_Load(object sender, EventArgs e)
        {
            if (SetupValues != null)
            {
                var model = new SetupGridViewModel()
                {
                    SetupName = "-"
                };

                foreach (var item in SetupValues)
                {
                    var section = model.SetupSections.FirstOrDefault(s => s.SectionName == item.Property.Path.Path);

                    if (section == null)
                    {
                        section = new SetupSectionViewModel()
                        {
                            SectionName = item.Property.Path.Path
                        };

                        model.SetupSections.Add(section);
                    }
                    var setupValue = new SetupValueViewModel()
                    {
                        Property = item.Property.Name,
                        Value = item.Value.ToString()
                    };
                    if (PreviousSetupValues != null && PreviousSetupValues.Count > 0)
                    {
                        var previousSetupValue = PreviousSetupValues.FirstOrDefault(p => p.Property.Name == item.Property.Name && p.Property.Path.Path == item.Property.Path.Path);

                        if (previousSetupValue != null)
                        {
                            setupValue.PreviousValue = previousSetupValue.Value.ToString();

                            if (item.Property.DataType == iRacing.SetupSettingDataTypes.irDouble ||
                                item.Property.DataType == iRacing.SetupSettingDataTypes.irDouble ||
                                item.Property.DataType == iRacing.SetupSettingDataTypes.irDouble)
                            {
                                setupValue.Delta = (previousSetupValue.Value - item.Value).ToString();
                            }
                        }
                    }
                    section.SetupValues.Add(setupValue);
                }

                this.setupView1.ViewModel = model;

            }
        }
    }
}
