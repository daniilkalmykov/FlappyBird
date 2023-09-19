using UnityEngine;

namespace Sources.LevelSettings
{
    [CreateAssetMenu(fileName = "New Level Settings", menuName = "Settings/Level Settings")]
    internal sealed class LevelSettings : ScriptableObject
    {
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }
        [field: SerializeField] public int PipesCount { get; private set; }
        [field: SerializeField] public MonoBehaviour Prefab { get; private set; }
        [field: SerializeField] public Difficulty Difficulty { get; private set; }
    }
}