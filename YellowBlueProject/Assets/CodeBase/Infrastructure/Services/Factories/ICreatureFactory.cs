using System;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
    public interface ICreatureFactory : IService
    {
        public GameObject Character { get; }
        public CharacterData CharacterData { get; }
        event Action<GameObject> OnCharacterCreated;
        public GameObject[] Enemies { get; }
        void CreateCharacter(CharacterData data, Vector3 at, Quaternion rotation);
        void CreateEnemy(EnemyData data, Vector3 at);
    }
}