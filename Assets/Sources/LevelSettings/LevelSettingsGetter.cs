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

            var setting = levelSettings.FirstOrDefault(foundSetting =>
                string.Equals(foundSetting.Difficulty.ToString(), levelSetting));

            return setting;
        }
    }
}