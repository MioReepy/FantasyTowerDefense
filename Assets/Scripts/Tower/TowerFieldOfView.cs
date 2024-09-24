using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSpace
{
    public class TowerFieldOfView :MonoBehaviour
    {
        [SerializeField] private LayerMask _targetMask;
        [Range(0, 50)] [SerializeField] internal float viewRadius = 10f;
        [SerializeField] private float _delayTime = 0.2f;
        private List<Transform> _visibleTarget;

        private void Start()
        {
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
                    _visibleTarget.Add(target);
                }
            }
        }

        private void DeleteInVisibleTarger()
        {
            for (int i = 0; i < _visibleTarget.Count; i++)
            {
                Vector3 directionToTarget = (_visibleTarget[i].position - transform.position).normalized;

                if (viewRadius >= directionToTarget.magnitude)
                {
                    _visibleTarget.Remove(_visibleTarget[i]);
                }
            }
        }
    }
}