using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "StaticData/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        [Header("View")] 
        public GameObject prefab;
        public string weaponName;
        [Range(1,10)] public int damage = 1;
    }
}