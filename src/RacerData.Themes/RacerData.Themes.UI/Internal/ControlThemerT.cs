using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Ports;

namespace RacerData.Themes.UI.Internal
{
    public class ControlThemer<T> : IControlThemer<T> where T : Control
    {
        #region public 

        public virtual void ApplyTheme<TControl>(TControl control, IThemeDefinition theme, bool applyToChildren) where TControl : Control
        {
            Console.WriteLine($"Applying theme {theme.Name} to {control.Name} (ApplyToChildren={applyToChildren})");
        }

        public virtual void ClearTheme<TControl>(TControl control, bool applyToChildren) where TControl : Control
        {
            Console.WriteLine($"Clearing theme from {control.Name}");

            if (control is PropertyGrid)
                return;

            if (applyToChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ClearTheme(child, true);
                }
            }

            control.Font = default(Font);

            if (!(control is MenuStrip || control is ToolStrip || control is StatusStrip || control is PictureBox))
                control.ForeColor = default(Color);

            control.BackColor = default(Color);

            if (control is Button)
            {
                var button = control as Button;

                if (button != null)
                {
                    button.UseVisualStyleBackColor = true;

                    if (button.FlatStyle == FlatStyle.Flat)
                    {
                        button.FlatAppearance.CheckedBackColor = default(Color);
                        button.FlatAppearance.MouseDownBackColor = default(Color);
                        button.FlatAppearance.MouseOverBackColor = default(Color);
                        button.FlatAppearance.CheckedBackColor = default(Color);
                        button.FlatAppearance.BorderColor = default(Color);
                        button.FlatAppearance.BorderSize = 1;
                    }
                    else
                    {
                        button.FlatAppearance.BorderColor = default(Color);
                        button.FlatAppearance.BorderSize = 0;
                    }
                }
            }

            if (!(control is MenuStrip || control is ToolStrip || control is StatusStrip || control is PictureBox))
                control.ForeColor = default(Color);

            control.BackColor = default(Color);
        }

        #endregion
    }
}
