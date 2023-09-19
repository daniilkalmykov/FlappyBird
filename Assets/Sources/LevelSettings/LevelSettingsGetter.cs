using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.LevelSettings
{
    internal static class LevelSettingsGetter
    {
        public static LevelSettings Get(IEnumerable<LevelSettings> levelSettings)
        {
            var levelSetting = PlayerData.PlayerData.GetLevelSettings();

            var settings = levelSettings as LevelSettings[] ?? levelSettings.ToArray();
            
            var setting = settings.FirstOrDefault(foundSetting =>
                string.Equals(foundSetting.Difficulty.ToString(), levelSetting));

            if (setting == null)
                setting = settings.FirstOrDefault(easySettings => easySettings.Difficulty == Difficulty.Easy);
            
            return setting;
        }
    }
}