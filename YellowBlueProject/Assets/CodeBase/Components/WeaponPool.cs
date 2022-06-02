using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factories;
using UnityEngine;

namespace CodeBase.Components
{
    public class WeaponPool : MonoBehaviour
    {
        [SerializeField] private int amountToPool;
        private List<GameObject> _pooledObjects;
        private IWeaponFactory _weaponFactory;
        private ICreatureFactory _creatureFactory;
    
        private void Awake()
        {
            _weaponFactory = ServiceLocator.Container.Single<IWeaponFactory>();
            _creatureFactory = ServiceLocator.Container.Single<ICreatureFactory>();
            _creatureFactory.OnCharacterCreated += InitPool;
        }

        private void InitPool(GameObject obj)
        {
            _pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject pooledWeapon = _weaponFactory.CreateWeapon();
                pooledWeapon.SetActive(false);
                _pooledObjects.Add(pooledWeapon);
            }
        }

        public GameObject GetPooledWeapon()
        {
            for(int i = 0; i < amountToPool; i++)
            {
                if(_pooledObjects[i].activeInHierarchy == false)
                {
                    return _pooledObjects[i];
                }
            }
            return null;
        }
    }
}