using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public partial class CreateViewWizard3 : WizardStep
    {
        #region fields

        private DisplayFormatMapService _mapService = null;
        private Point _dragPoint = Point.Empty;
        private Point _dragPointToClient = Point.Empty;
        private Panel _dragFrame;
        private bool _allowResize = false;

        #endregion

        #region properties

        private IList<ViewDataMember> _dataMembers = null;
        public IList<ViewDataMember> DataMembers
        {
            get
            {
                return _dataMembers;
            }
            set
            {
                _dataMembers = value;
                OnPropertyChanged(nameof(DataMembers));
            }
        }

        #endregion

        #region ctor/load

        public CreateViewWizard3()
        {
            InitializeComponent();

            Index = 2;
            Name = "Set field order";
            Caption = "Set the field order and sizes";
            Details = "Set the order the fields are shown and the size for each field for the view.";
            Error = String.Empty;
        }

        private void CreateViewWizard3_Load(object sender, EventArgs e)
        {
            lblCaption.Text = Caption;

            _mapService = new DisplayFormatMapService();

            _dragFrame = new Panel()
            {
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            Controls.Add(_dragFrame);

            dragTimer.Tick += DragTimer_Tick;
        }

        #endregion

        #region public 

        public override object GetDataSource()
        {
            return null;
        }

        public override void SetDataObject(object data)
        {
            DataMembers = (IList<ViewDataMember>)data;
        }

        public override void ActivateStep()
        {
            base.ActivateStep();

            DisplayFields();

            UpdateValidation();
        }

        public override void DeactivateStep()
        {
            base.DeactivateStep();
        }

        public override bool ValidateStep()
        {
            bool isValid = true;
            Error = "";

            return isValid;
        }

        #endregion

        #region protected

        protected virtual void DisplayFields()
        {
            pnlFields.Controls.Clear();
            pnlCaptions.Controls.Clear();

            foreach (var field in DataMembers)
            {
                var mapItem = new DataFormatMapItem()
                {
                    DataMember = field
                };

                if (_mapService.Map.ContainsKey(field))
                {
                    mapItem.DisplayFormat = _mapService.Map[field];
                }

                var captionLabel = GetCaptionLabel(mapItem);
                pnlCaptions.Controls.Add(captionLabel);

                var fieldLabel = GetLabel(mapItem);
                pnlFields.Controls.Add(fieldLabel);
            }
        }

        protected virtual Label GetCaptionLabel(DataFormatMapItem mapItem)
        {
            Label label = new Label();

            var width = mapItem.DisplayFormat != null ? mapItem.DisplayFormat.MaxWidth.HasValue ? mapItem.DisplayFormat.MaxWidth.Value : 100 : 100;
            label.Size = new System.Drawing.Size(width, pnlFields.Height);

            var text = mapItem.DataMember.Caption;

            label.Text = text;
            label.Name = "lbl" + mapItem.DataMember.Name + "Caption";
            label.TextAlign = mapItem.DisplayFormat != null ?
                mapItem.DisplayFormat.Alignment == HorizontalAlignment.Left ?
                System.Drawing.ContentAlignment.MiddleLeft :
                mapItem.DisplayFormat.Alignment == HorizontalAlignment.Right ?
                System.Drawing.ContentAlignment.MiddleRight :
                System.Drawing.ContentAlignment.MiddleCenter :
                System.Drawing.ContentAlignment.MiddleCenter;
            label.ForeColor = Color.Black;
            label.BackColor = Color.White;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Margin = new Padding(2, 3, 0, 3);

            return label;
        }
        protected virtual Label GetLabel(DataFormatMapItem mapItem)
        {
            Label label = new Label();

            var width = mapItem.DisplayFormat != null ? mapItem.DisplayFormat.MaxWidth.HasValue ? mapItem.DisplayFormat.MaxWidth.Value : 100 : 100;
            label.Size = new System.Drawing.Size(width, pnlFields.Height);

            var text = mapItem.DisplayFormat != null && mapItem.DisplayFormat.Sample != "" ? mapItem.DisplayFormat.Sample : mapItem.DataMember.Name;

            label.Text = text;
            label.Name = "lbl" + mapItem.DataMember.Name;
            label.TextAlign = mapItem.DisplayFormat != null ?
                mapItem.DisplayFormat.Alignment == HorizontalAlignment.Left ?
                System.Drawing.ContentAlignment.MiddleLeft :
                mapItem.DisplayFormat.Alignment == HorizontalAlignment.Right ?
                System.Drawing.ContentAlignment.MiddleRight :
                System.Drawing.ContentAlignment.MiddleCenter :
                System.Drawing.ContentAlignment.MiddleCenter;
            label.ForeColor = Color.Black;
            label.BackColor = Color.FromKnownColor(KnownColor.Control);
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Margin = new Padding(2, 3, 0, 3);

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(10, 10);
            pictureBox1.Location = new Point(label.Width - pictureBox1.Width, label.Height - pictureBox1.Height);
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Cursor = Cursors.SizeWE;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            label.Controls.Add(pictureBox1);
            pictureBox1.BringToFront();

            ConfigureDragging(label);

            return label;
        }

        protected virtual void UpdateValidation()
        {
            IsComplete = ValidateStep();
        }

        #endregion

        #region resize
        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = false;
            ResetCaptionSizes();
        }
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_allowResize)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Label parent = (Label)pictureBox.Parent;
                parent.Width = pictureBox.Left + e.X;
            }
        }
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = true;
        }
        private void CreateViewWizard3_MouseMove(object sender, MouseEventArgs e)
        {
            _allowResize = false;
            ResetCaptionSizes();
        }
        private void ResetCaptionSizes()
        {
            for (int i = 0; i < pnlFields.Controls.Count; i++)
            {
                var fieldLabel = pnlFields.Controls[i];
                var captionLabel = pnlCaptions.Controls[i];

                captionLabel.Size = fieldLabel.Size;
            }
        }
        #endregion

        #region drag/drop     
        protected virtual void ConfigureDragging(Label ctl)
        {
            ctl.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragPoint = e.Location;

                    dragTimer.Start();

                    _dragFrame.Size = ctl.Size;

                    Point pt = this.PointToClient(Cursor.Position);

                    _dragPointToClient = pt;

                    _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                                   pt.Y + 3);

                    if (_dragFrame.BackgroundImage != null)
                        _dragFrame.BackgroundImage.Dispose();
                    Bitmap bmp = new Bitmap(_dragFrame.ClientSize.Width,
                                            _dragFrame.ClientSize.Height);
                    ctl.DrawToBitmap(bmp, _dragFrame.ClientRectangle);
                    _dragFrame.BackgroundImage = bmp;

                    _dragFrame.BringToFront();
                    _dragFrame.Show();
                    ctl.DoDragDrop(ctl, DragDropEffects.Copy | DragDropEffects.Move);
                }
            };

            ctl.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragFrame.Hide();
                    dragTimer.Stop();
                }
            };

            ctl.Leave += (s, e) =>
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            };
        }
        protected virtual void DragTimer_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            }

            if (_dragFrame.Visible)
            {
                Point pt = this.PointToClient(Cursor.Position);

                _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                               pt.Y + 3);
            }
        }
        private void pnlFields_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void pnlFields_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                _dragFrame.Hide();
                dragTimer.Stop();
                Label controlBase = e.Data.GetData(e.Data.GetFormats()[0]) as Label;
                bool inserted = false;
                if (controlBase != null)
                {
                    var hitPoint = this.pnlFields.PointToClient(new Point(e.X, e.Y));
                    var dragPoint = this.pnlFields.PointToClient(_dragPoint);

                    IList<Label> labelBuffer = new List<Label>();

                    var originalLabels = pnlFields.
                        Controls.
                        OfType<Label>().
                        Where(l => l.Name != controlBase.Name).
                        OrderBy(l => l.Location.X).
                        ToList();

                    for (int i = 0; i < originalLabels.Count; i++)
                    {
                        var target = originalLabels[i];

                        Console.WriteLine($"target:{target.Location.ToString()} hitPoint:{hitPoint.ToString()} _dragPointToClient:{_dragPointToClient.ToString()}");
                        Console.WriteLine("_______________________________________");
                        if (!inserted && hitPoint.X < target.Location.X)
                        {
                            Console.WriteLine("hitPoint.X < target.Location.X");
                            Console.WriteLine("adding controlBase, then target");
                            //labelBuffer.Add(target);
                            //controlBase.Location = target.Location;
                            //target.Location = new Point(target.Location.X + target.Width, target.Location.Y);
                            labelBuffer.Add(controlBase);
                            labelBuffer.Add(target);
                            inserted = true;
                        }
                        else if (!inserted && hitPoint.X >= target.Location.X && hitPoint.X <= target.Location.X + target.Width)
                        {
                            Console.WriteLine("!inserted && hitPoint.X >= target.Location.X && hitPoint.X <= target.Location.X + target.Width");

                            //controlBase.Location = target.Location;
                            //target.Location = new Point(target.Location.X + target.Width, target.Location.Y);
                            if (_dragPointToClient.X < hitPoint.X)
                            {
                                Console.WriteLine("moving to the right, adding target, then controlBase");
                                // moving to the right
                                labelBuffer.Add(target);
                                labelBuffer.Add(controlBase);
                            }
                            else
                            {
                                Console.WriteLine("moving to the left, adding controlBase, then target");
                                // moving to the left
                                labelBuffer.Add(controlBase);
                                labelBuffer.Add(target);
                            }
                            inserted = true;
                        }
                        else
                        {
                            Console.WriteLine("else");
                            Console.WriteLine("adding target");
                            //target.Location = new Point(target.Location.X + target.Width, target.Location.Y);
                            labelBuffer.Add(target);
                        }
                        Console.WriteLine();
                    }

                    if (!inserted)
                    {
                        Console.WriteLine("!inserted");
                        Console.WriteLine("adding controlBase");
                        labelBuffer.Add(controlBase);
                    }

                    //foreach (Label fieldLabel in pnlFields.Controls.OfType<Label>())
                    //{
                    //    var start = fieldLabel.Location.X;
                    //    var end = start + fieldLabel.Width;
                    //    if (hitPoint.X < end && !inserted && (fieldLabel.Name != controlBase.Name))
                    //    {
                    //        // insert it here.
                    //        labelBuffer.Add(controlBase);
                    //        inserted = true;
                    //        labelBuffer.Add(fieldLabel);
                    //    }
                    //    else
                    //    {
                    //        labelBuffer.Add(fieldLabel);
                    //    }
                    //}
                    var captionLabels = pnlCaptions.Controls.OfType<Label>().ToList();

                    pnlFields.Controls.Clear();
                    pnlCaptions.Controls.Clear();

                    int offset = 0;
                    for (int i = 0; i < labelBuffer.Count; i++)
                    {
                        var target = labelBuffer[i];
                        var targetCaption = captionLabels.FirstOrDefault(l => l.Name == target.Name + "Caption");
                        target.Location = new Point(pnlFields.Margin.Left + offset, target.Location.Y);
                        targetCaption.Location = new Point(pnlCaptions.Margin.Left + offset, target.Location.Y);
                        pnlFields.Controls.Add(target);
                        pnlCaptions.Controls.Add(targetCaption);
                        offset += target.Width;
                    }
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Can't move field here", "Invalid Move", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error moving field", ex);
            }
        }
        #endregion
    }
}
