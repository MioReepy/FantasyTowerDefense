using UnityEngine;

namespace TowerSpace
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float _speedRotate = 100f;

        private TowerFieldOfView _towerFieldOfView;

        private void Start()
        {
            _towerFieldOfView = GetComponent<TowerFieldOfView>();
        }

        private void Update()
        {
            if (_towerFieldOfView.target != null)
            {
                Vector3 lookRotation = Quaternion.LookRotation(_towerFieldOfView.target.position - transform.position).eulerAngles;
                Quaternion rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _speedRotate);
            }

        }
    }
}