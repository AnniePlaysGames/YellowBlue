using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly ICreatureFactory _creatureFactory;
        private WeaponData _data;

        public WeaponFactory(ICreatureFactory creatureFactory)
        {
            _creatureFactory = creatureFactory;
        }
        
        public GameObject CreateWeapon()
        {
            _data = _creatureFactory.CharacterData.weapon;
            GameObject prefab = _data.prefab;
            GameObject weapon = Object.Instantiate(prefab);
            weapon.GetComponent<Weapon>().AttackData(_data);
            return weapon;
        }
    }
}