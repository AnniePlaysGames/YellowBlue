using System;
using System.Collections.Generic;
using CodeBase.Components;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Services.Factories
{
    public class CreatureFactory : ICreatureFactory
    {
        public GameObject Character { get; private set; }
        public CharacterData CharacterData { get; private set; }
        public GameObject[] Enemies => _enemies.ToArray();
        
        public event Action<GameObject> OnCharacterCreated;
        private List<GameObject> _enemies = new List<GameObject>();

        public void CreateCharacter(CharacterData data, Vector3 at, Quaternion rotation)
        {
            CharacterData = data;
            GameObject prefab = data.prefab;
            AttachCharacterData(to: prefab, from: data);
            Character = Object.Instantiate(prefab, at, rotation);
            OnCharacterCreated?.Invoke(Character);
        }

        public void CreateEnemy(EnemyData data, Vector3 at)
        {
            GameObject prefab = data.prefab;
            AttachEnemyData(to: prefab, from: data);
            _enemies.Add(Object.Instantiate(prefab, at, Quaternion.identity));
        }

        private void AttachEnemyData(GameObject to, EnemyData from)
        {
            to.GetComponent<Damageable>().InitHealth(from.health);
            to.GetComponent<Rigidbody>().isKinematic = true;
        }

        private void AttachCharacterData(GameObject to, CharacterData from)
        {
            to.GetComponent<NavMeshAgent>().speed = from.speed;
        }
    }
}