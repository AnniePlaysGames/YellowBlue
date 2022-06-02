using System.Collections;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(WeaponPool))]
    [RequireComponent(typeof(CharacterAnimator))]
    [RequireComponent(typeof(BallisticsProjectiveSpawner))]
    public class Attack : MonoBehaviour
    {
        private const int RaycastMaxDistance = 50;
        [SerializeField] private float _throwAngleInDegree;

        private IInputService _inputService;
        private CharacterAnimator _animator;

        private GameObject _weapon;
        private Transform _attachWeaponPoint;
        private WeaponPool _weaponPool;
        private bool _canShowWeapon = true;
        private BallisticsProjectiveSpawner _weaponProjectiveSpawner;
        private Vector3 _currentHitPoint;

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Single<IInputService>();
            _inputService.OnClickRay += DoAttack;
            _animator = GetComponent<CharacterAnimator>();

            _weaponPool = GetComponent<WeaponPool>();
            _attachWeaponPoint = GetComponentInChildren<AttachWeaponPoint>().gameObject.transform;
            _weaponProjectiveSpawner = GetComponent<BallisticsProjectiveSpawner>();
            _weapon = GetComponentInChildren<Weapon>().gameObject;
        }

        private void OnDisable()
            => _inputService.OnClickRay -= DoAttack;

        private void DoAttack(Ray ray)
        {
            if (Physics.Raycast(ray, out var hit, RaycastMaxDistance))
            {
                _currentHitPoint = hit.point;
                _animator.DoAttack();
            }
            else
            {
                _currentHitPoint = ray.GetPoint(RaycastMaxDistance);
            }
        }

        public void AttackAnimationEvent() // On CharacterAnimator.DoAttack throwing
        {
            StartCoroutine(HideWeaponInHand());
            _weaponProjectiveSpawner.Shot(_attachWeaponPoint.position, _currentHitPoint, 
                _throwAngleInDegree, _weaponPool);
        }

        public void ShowWeaponAnimationEvent()
            => _canShowWeapon = true;

        IEnumerator HideWeaponInHand()
        {
            _canShowWeapon = false;
            _weapon.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitUntil(() => _canShowWeapon);
            _weapon.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}