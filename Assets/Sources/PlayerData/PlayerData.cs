using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("LevelSettings")]
namespace Sources.PlayerData
{
    public static class PlayerData
    {
        private const string LevelSettings = "LevelSettings";

        public static void SetLevelSettings(string levelSettings)
        {
            PlayerPrefs.SetString(LevelSettings, levelSettings);
        }

        public static string GetLevelSettings()
        {
            return PlayerPrefs.GetString(LevelSettings);
        }
    }
}