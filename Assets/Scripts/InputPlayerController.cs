using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayerController : MonoBehaviour
{
    private PlayerInput _playerInputController;
    private InputAction _actionMove;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInput>();
        _actionMove = _playerInputController.actions["Move"];
        _playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        Vector2 move = _actionMove.ReadValue<Vector2>();
        _playerController.MoveInput = move;
    }
}