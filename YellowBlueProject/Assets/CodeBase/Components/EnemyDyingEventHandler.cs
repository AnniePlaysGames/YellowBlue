using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factories;
using UnityEngine;

namespace CodeBase.Components
{
    public class EnemyDyingEventHandler : MonoBehaviour
    {
        public Action<GameObject> OnEnemyDied;
        private ICreatureFactory _creatureFactory;

        private void Awake()
        {
            _creatureFactory = ServiceLocator.Container.Single<ICreatureFactory>();
        }

        private void Start()
        {
            foreach (GameObject enemy in _creatureFactory.Enemies)
            {
                enemy.GetComponent<Damageable>().OnDie += OnDie;
            }
        }

        private void OnDie(GameObject obj)
        {
            OnEnemyDied.Invoke(obj);
        }
    }
}