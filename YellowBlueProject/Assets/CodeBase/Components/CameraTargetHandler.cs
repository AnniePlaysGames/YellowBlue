using Cinemachine;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factories;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraTargetHandler : MonoBehaviour
    {
        private ICreatureFactory _creatureFactory;
        private CinemachineVirtualCamera _camera;

        private void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            _creatureFactory = ServiceLocator.Container.Single<ICreatureFactory>();
            _creatureFactory.OnCharacterCreated += SetTarget;
        }
    
        private void SetTarget(GameObject target)
        {
            GameObject lookPoint = target.GetComponentInChildren<CameraTarget>().gameObject;
            ;       _camera.Follow = lookPoint.transform;
            _camera.LookAt = lookPoint.transform;
        }
    }
}