using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy", order = 1)]
    public class EnemyData : ScriptableObject
    {
        [Header("View")] 
        public GameObject prefab;
        
        [Header("Logic")] 
        [Range(1, 10)] public int health = 1;
    }
}