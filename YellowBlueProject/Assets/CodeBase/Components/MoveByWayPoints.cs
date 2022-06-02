using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Components
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class MoveByWayPoints : MonoBehaviour
    {
        private ISpawnService _spawnService;
        private IInputService _inputService;
        
        private WayPoint[] _waypoints;
        private int _nextPointIndex = 0;
        private NavMeshAgent _agent;
        private CharacterAnimator _animator;
        private WayPoint _currentWayPoint;

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Single<IInputService>();
            _spawnService = ServiceLocator.Container.Single<ISpawnService>();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<CharacterAnimator>();
        }

        public void StartMovement() 
            => MoveToNextWayPoint();

        private void MoveToNextWayPoint()
        {
            _inputService.DisableInput();
            if (_currentWayPoint != null)
            {
                _currentWayPoint.OnTaskComplete -= MoveToNextWayPoint;
            }
        
            _agent.SetDestination(_waypoints[_nextPointIndex].transform.position);
            _agent.isStopped = false;
            _animator.StartMove();
            _nextPointIndex++;
        }

        private void Start() 
            => _waypoints = _spawnService.WayPoints;

        private void OnTriggerEnter(Collider other)
        {
            WayPoint point = other.GetComponent<WayPoint>();
            if (point != null)
            {
                _inputService.EnableInput();
                _currentWayPoint = point;
                _currentWayPoint.OnTaskComplete += MoveToNextWayPoint;
                point.SetAsCurrentPoint();
                _agent.isStopped = true;
                _animator.FinishMove();
            }
        }
    }
}
