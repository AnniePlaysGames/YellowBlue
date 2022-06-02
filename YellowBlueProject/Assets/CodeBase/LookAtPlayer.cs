using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factories;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject _target;
    private ICreatureFactory _creatureFactory;

    private void Awake() 
        => _creatureFactory = ServiceLocator.Container.Single<ICreatureFactory>();

    private void Start() 
        => _target = _creatureFactory.Character;

    private void Update() 
        => transform.LookAt(_target.transform.position);
}
