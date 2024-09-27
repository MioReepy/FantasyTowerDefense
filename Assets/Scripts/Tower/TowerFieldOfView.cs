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
                    int index = 1;
                    
                    for (int i = 0; i < visibleTarget.Count; i++)
                    {
                        if (visibleTarget[i].GetComponent<WaypointNavigator>()._currentWaypoint.transform
                                .GetSiblingIndex() > index)
                        {
                            if (target == null && visibleTarget[i] == null)
                            {
                                break;
                            }
                            
                            target = visibleTarget[i].transform;
                            index = visibleTarget[i].GetComponent<WaypointNavigator>()._currentWaypoint.transform
                                .GetSiblingIndex();
                        }
                    }
                    
                    DeleteInVisibleTarger();
                }
            }
        }

        private void FindVisibleTarget()
        {
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, _targetMask);

            foreach (var target in targetsInViewRadius)
            {
                if (!visibleTarget.Contains(target.transform))
                {
                    visibleTarget.Add(target.transform);
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