using System;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using RacerData.Commmon.Results;
using RacerData.Common.Ports;
using RacerData.Common.Results;
using RacerData.Data.Json.Adapters;
using RacerData.Themes.Models;
using RacerData.Themes.Ports;

namespace RacerData.Themes.UI.Adapters
{
    class ThemeDefinitionRepository : JsonRepository<ThemeDefinition, Guid>, IThemeDefinitionRepository
    {
        #region properties

        protected override string JsonFileName { get; set; } = "themeDefinitions.json";

        #endregion

        #region ctor

        public ThemeDefinitionRepository(
           ILog log,
           IDirectoryService directoryService,
           ISerializer serializer,
           IRevertableService revertableService,
           IResultFactory<JsonRepository<ThemeDefinition, Guid>> resultFactory)
            : base(log, directoryService, serializer, revertableService, resultFactory)
        {
            //Items.Add((ThemeDefinition)StandardThemes.BlackTheme);
            //Items.Add((ThemeDefinition)StandardThemes.BlueTheme);
            //Items.Add((ThemeDefinition)StandardThemes.SystemTheme);
        }

        #endregion

        #region public

        public async Task<IResult<ThemeDefinition>> SelectThemeAsync(string name)
        {
            try
            {
                ThemeDefinition item = GetItemFromList(name);

                if (item == null)
                {
                    return await Task.FromResult(_resultFactory.NotFound<ThemeDefinition>());
                }

                return await Task.FromResult(_resultFactory.Success<ThemeDefinition>(item));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<ThemeDefinition>(ex));
            }
        }

        #endregion

        #region protected

        /// <summary>
        /// Overridden to take advantage of typed comparison.
        /// Generics cannot be compared with ==
        /// </summary>
        protected override ThemeDefinition GetItemFromList(Guid key)
        {
            return Items.FirstOrDefault(i => i.Key == key);
        }

        protected virtual ThemeDefinition GetItemFromList(string name)
        {
            return Items.FirstOrDefault(i => i.Name == name);
        }

        #endregion
    }
}
