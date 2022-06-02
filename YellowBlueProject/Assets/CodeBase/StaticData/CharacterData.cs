using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "StaticData/Character", order = 1)]
    public class CharacterData : ScriptableObject
    {
        [Header("View")] 
        public GameObject prefab;
        
        [Header("Logic")]
        public float speed = 1;
        public WeaponData weapon;
    }
}