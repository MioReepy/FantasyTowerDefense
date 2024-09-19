using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Boundary _boundary;
    [SerializeField] private float _smoothSpeed = 0.125f;
    private Vector3 _playerPosition;
    private Vector3 _offset;

    public Vector2 MoveInput
    {
        set
        {
            _playerPosition.x = value.x;
            _playerPosition.z = value.y;
        }
    }

    private void LateUpdate()
    {
        Vector3 movePosition = transform.position + _playerPosition;
        transform.position = new Vector3(Mathf.Clamp(movePosition.x, _boundary.xMin, _boundary.xMax), Mathf.Clamp(movePosition.z, _boundary.zMin, _boundary.zMax));
        Debug.Log(_playerPosition);
    }
}
