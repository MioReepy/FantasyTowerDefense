using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayerController : MonoBehaviour
{
    private PlayerInput _playerInputController;
    private InputAction _actionMove;
    private CameraFollow _cameraFollow;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInput>();
        _actionMove = _playerInputController.actions["Move"];
        _cameraFollow = GetComponent<CameraFollow>();
    }

    private void FixedUpdate()
    {
        Vector2 move = _actionMove.ReadValue<Vector2>();
        _cameraFollow.MoveInput = move;
    }
}
