using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using RacerData.Commmon.Results;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Internal;
using RacerData.Themes.UI.Ports;

namespace RacerData.Themes.UI.Adapters
{
    class ThemeUiService : IThemeUiService
    {
        #region delegates

        private delegate void ApplyThemeDelegate(Control control, IThemeDefinition theme, bool applyToChildren);
        private delegate void ClearThemeDelegate(Control control, bool applyToChildren);

        #endregion

        #region fields

        private readonly ILog _log;
        private readonly IThemeDefinitionRepository _themeRepository;

        #endregion

        #region ctor

        public ThemeUiService(
            ILog log,
            IThemeDefinitionRepository themeRepository)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _themeRepository = themeRepository ?? throw new ArgumentNullException(nameof(themeRepository));
        }

        #endregion

        #region public

        public async Task ApplyThemeAsync(Control control, string themeName, bool applyToChildren)
        {
            try
            {
                if (control == null)
                    throw new ArgumentNullException(nameof(control));

                if (String.IsNullOrEmpty(themeName))
                    throw new ArgumentNullException(nameof(themeName));

                var theme = await GetThemeAsync(themeName);

                if (theme == null)
                    throw new ArgumentException(nameof(control));

                await Task.Run(() => { ApplyThemeToControl(control, theme, applyToChildren); });

            }
            catch (ArgumentException ex)
            {
                _log?.Error($"Error applying theme: No theme found with name {themeName}", ex);
            }
            catch (Exception ex)
            {
                _log?.Error("Error applying theme", ex);
            }
        }

        public async Task ApplyThemeAsync(Control control, Guid themeId, bool applyToChildren)
        {
            try
            {
                if (control == null)
                    throw new ArgumentNullException(nameof(control));

                if (themeId == Guid.Empty)
                    throw new ArgumentNullException(nameof(themeId));

                var theme = await GetThemeAsync(themeId);

                if (theme == null)
                    throw new ArgumentException(nameof(control));

                await Task.Run(() => { ApplyThemeToControl(control, theme, applyToChildren); });

            }
            catch (ArgumentException ex)
            {
                _log?.Error($"Error applying theme: No theme found with id {themeId}", ex);
            }
            catch (Exception ex)
            {
                _log?.Error("Error applying theme", ex);
            }
        }

        public async Task ApplyThemeAsync(Control control, IThemeDefinition theme, bool applyToChildren)
        {
            await Task.Run(() => { ApplyThemeToControl(control, theme, applyToChildren); });
        }

        public async Task ClearThemeAsync(Control control, bool applyToChildren)
        {
            await Task.Run(() => { ClearThemeFromControl(control, applyToChildren); });
        }

        #endregion

        #region protected

        protected virtual async Task<IThemeDefinition> GetThemeAsync(Guid id)
        {
            var result = await _themeRepository.SelectAsync(id);

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            return result.Value;
        }

        protected virtual async Task<IThemeDefinition> GetThemeAsync(string name)
        {
            var result = await _themeRepository.SelectThemeAsync(name);

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            return result.Value;
        }

        protected virtual void ClearThemeFromControl(Control control)
        {
            ClearThemeFromControl(control, true);
        }
        protected virtual void ClearThemeFromControl(Control control, bool applyToChildren)
        {
            if (control.InvokeRequired)
            {
                var d = new ClearThemeDelegate(ClearThemeFromControl);
                control.Invoke(d, new object[] { control, applyToChildren });
            }
            else
            {
                if (control is Form)
                {
                    var themer = new FormThemer();

                    themer.ClearTheme((Form)control, applyToChildren);
                }

                else if (control is Button)
                {
                    var themer = new ButtonThemer();

                    themer.ClearTheme((Form)control, applyToChildren);
                }
                else if (control is Label)
                {
                    var themer = new LabelThemer();

                    themer.ClearTheme((Label)control, applyToChildren);
                }
                else if (control is TextBox)
                {
                    var themer = new TextBoxThemer();

                    themer.ClearTheme((TextBox)control, applyToChildren);
                }
                else if (control is ComboBox)
                {
                    var themer = new TextBoxThemer();

                    themer.ClearTheme((ComboBox)control, applyToChildren);
                }
                else if (control is ListBox)
                {
                    var themer = new DefaultThemer();

                    themer.ClearTheme((ListBox)control, applyToChildren);
                }
                else if (control is NumericUpDown)
                {
                    var themer = new DefaultThemer();

                    themer.ClearTheme((NumericUpDown)control, applyToChildren);
                }
                else if (control is Panel || control is FlowLayoutPanel || control is TableLayoutPanel)
                {
                    var themer = new PanelThemer();

                    themer.ClearTheme((Panel)control, applyToChildren);
                }
                else if (control is MenuStrip)
                {
                    var themer = new MenuStripThemer();

                    themer.ClearTheme((MenuStrip)control, applyToChildren);
                }
                else if (control is ToolStrip)
                {
                    var themer = new ToolStripThemer();

                    themer.ClearTheme((ToolStrip)control, applyToChildren);
                }
                else if (control is StatusStrip)
                {
                    var themer = new StatusStripThemer();

                    themer.ClearTheme((StatusStrip)control, applyToChildren);
                }
                else if (control is Form)
                {
                    var themer = new FormThemer();

                    themer.ClearTheme((Form)control, applyToChildren);
                }
                else
                {
                    var themer = new DefaultThemer();

                    themer.ClearTheme(control, applyToChildren);
                }
            }
        }

        protected virtual void ApplyThemeToControl(Control control, IThemeDefinition theme)
        {
            ApplyThemeToControl(control, theme, true);
        }
        protected virtual void ApplyThemeToControl(Control control, IThemeDefinition theme, bool applyToChildren)
        {
            if (control.InvokeRequired)
            {
                var d = new ApplyThemeDelegate(ApplyThemeToControl);
                control.Invoke(d, new object[] { control, theme, applyToChildren });
            }
            else
            {
                if (control is Form)
                {
                    var themer = new FormThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is Button)
                {
                    var themer = new ButtonThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is Label)
                {
                    var themer = new LabelThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is TextBox)
                {
                    var themer = new TextBoxThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is ComboBox)
                {
                    var themer = new DefaultThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is ListBox)
                {
                    var themer = new TextBoxThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is NumericUpDown)
                {
                    var themer = new DefaultThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is Panel || control is FlowLayoutPanel || control is TableLayoutPanel)
                {
                    var themer = new PanelThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is MenuStrip)
                {
                    var themer = new MenuStripThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is ToolStrip)
                {
                    var themer = new ToolStripThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is StatusStrip)
                {
                    var themer = new StatusStripThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else if (control is Form)
                {
                    var themer = new FormThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
                else
                {
                    var themer = new DefaultThemer();

                    themer.ApplyTheme(control, theme, applyToChildren);
                }
            }
        }

        #endregion
    }
}
