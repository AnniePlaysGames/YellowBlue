using System;
using UnityEngine;

namespace CodeBase.Components
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private int index;
        [SerializeField] private int requireKills = 0;
    
        public int RequireKills => requireKills;
        public Action OnTaskComplete;
        private EnemyDyingEventHandler _enemyDieHandler;

        private void Start()
        {
            _enemyDieHandler = GetComponentInParent<EnemyDyingEventHandler>();
        }

        public void SetAsCurrentPoint()
        {
            if (RequireKills == 0)
            {
                OnTaskComplete?.Invoke();
            }
            _enemyDieHandler.OnEnemyDied += OnEnemyKill;
        }
        private void OnEnemyKill(GameObject enemy)
        {
            requireKills--;
            if (requireKills == 0)
            {
                OnTaskComplete?.Invoke();
                _enemyDieHandler.OnEnemyDied -= OnEnemyKill;
            }
        }

#if (UNITY_EDITOR)
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            int arrowHeadLength = 1;
            int arrowHeadAngle = 15;
            int arrowBodyLength = 5;
        
            Vector3 direction = transform.forward * arrowBodyLength;
            Gizmos.DrawRay(transform.position, direction);
       
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0,180+ arrowHeadAngle,0) * new Vector3(0,0,1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0,180-arrowHeadAngle,0) * new Vector3(0,0,1);
            Gizmos.DrawRay(transform.position + direction, right * arrowHeadLength);
            Gizmos.DrawRay(transform.position + direction, left * arrowHeadLength);
        }
#endif
    }
}