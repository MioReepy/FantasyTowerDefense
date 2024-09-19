using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 0.125f;
    private Boundary _boundary;

    private void Start()
    {
        _boundary = GetComponent<Boundary>();
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _playerPosition.position + _offset;
        Vector3 movePosition = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed);
        transform.position = new Vector3(Mathf.Clamp(movePosition.x, _boundary.xMin, _boundary.xMax), Mathf.Clamp(movePosition.z, _boundary.zMin, _boundary.zMax));
    }
}
