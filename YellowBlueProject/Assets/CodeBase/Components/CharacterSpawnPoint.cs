using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factories;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Components
{
    public class CharacterSpawnPoint : MonoBehaviour
    {
        [SerializeField] private CharacterData target;
        private ICreatureFactory _creatureFactory;

        private void Awake() 
            => _creatureFactory = ServiceLocator.Container.Single<ICreatureFactory>();

        public void Spawn()
        {
            _creatureFactory.CreateCharacter(target, transform.position, transform.rotation);
        }
    }
}