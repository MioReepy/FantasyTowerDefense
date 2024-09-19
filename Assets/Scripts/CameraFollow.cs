using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Boundary _boundary;

    private void LateUpdate()
    {
        Vector3 movePosition = _playerPosition.position + _offset;
        transform.position = new Vector3(Mathf.Clamp(movePosition.x, _boundary.xMin, _boundary.xMax), Mathf.Clamp(movePosition.z, _boundary.zMin, _boundary.zMax));
        Debug.Log(_playerPosition);
    }
}
