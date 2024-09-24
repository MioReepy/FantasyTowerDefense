using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSpace
{
    public class TowerFieldOfView :MonoBehaviour
    {
        [SerializeField] private LayerMask _targetMask;
        [Range(0, 50)] [SerializeField] internal float viewRadius = 30f;
        [SerializeField] private float _delayTime = 0.5f;
        internal List<Transform> visibleTarget;

        private void Start()
        {
            visibleTarget = new List<Transform>();
            StartCoroutine("FindTarget", _delayTime);        
        }

        IEnumerator FindTarget(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTarget();
                DeleteInVisibleTarger();
            }
        }

        private void FindVisibleTarget()
        {
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, _targetMask);

            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Physics.Raycast(transform.position, directionToTarget, _targetMask))
                {
                    visibleTarget.Add(target);

                    for (int j = 0; j < visibleTarget.Count; j++)
                    {
                        Debug.Log(visibleTarget[j].name);
                    }
                    Debug.Log(visibleTarget[i].name);
                }
            }
        }

        private void DeleteInVisibleTarger()
        {
            if (visibleTarget != null)
            {
                for (int i = 0; i < visibleTarget.Count; i++)
                {
                    Vector3 directionToTarget = (visibleTarget[i].position - transform.position).normalized;

                    if (viewRadius > directionToTarget.magnitude)
                    {
                        visibleTarget.Remove(visibleTarget[i]);
                    }
                }
            }
        }
    }
}