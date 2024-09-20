using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Boundary _boundary;
    [SerializeField] private float _speed;
    private Vector3 _moveInput;

    public Vector2 MoveInput
    {
        set
        {
            _moveInput.x = value.x;
            _moveInput.z = value.y;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movePosition = transform.position + _moveInput;
        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(Mathf.Clamp(movePosition.x, _boundary.xMin, _boundary.xMax), transform.position.y, 
                Mathf.Clamp(movePosition.z, _boundary.zMin, _boundary.zMax)), _speed * Time.fixedDeltaTime);
    }
}