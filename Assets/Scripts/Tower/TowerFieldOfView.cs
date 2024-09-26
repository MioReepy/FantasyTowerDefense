using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointSpase;

namespace TowerSpace
{
    public class TowerFieldOfView :MonoBehaviour
    {
        [SerializeField] private LayerMask _targetMask;
        [Range(0, 50)] [SerializeField] internal float viewRadius = 30f;
        [SerializeField] private float _delayTime = 0.5f;
        internal List<Transform> visibleTarget;
        internal Transform target;

        private void Start()
        {
            visibleTarget = new List<Transform>();
            StartCoroutine(FindTarget());        
        }

        IEnumerator FindTarget()
        {
            while (true)
            {
                yield return new WaitForSeconds(_delayTime);
                
                FindVisibleTarget();

                if (visibleTarget.Count > 0)
                {
                    target = visibleTarget[0];
                    DeleteInVisibleTarger();
                }
            }
        }

        private void FindVisibleTarget()
        {
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, _targetMask);

            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {

                if (!visibleTarget.Contains(targetsInViewRadius[i].transform))
                {
                    visibleTarget.Add(targetsInViewRadius[i].transform);
                }
            }
        }

        private void DeleteInVisibleTarger()
        {
            for (int i = 0; i < visibleTarget.Count; i++)
            {
                Vector3 directionToTarget = visibleTarget[i].position - transform.position;

                if (viewRadius * viewRadius < directionToTarget.sqrMagnitude)
                {
                    visibleTarget.Remove(visibleTarget[i]);
                }
            }
        }
    }
}