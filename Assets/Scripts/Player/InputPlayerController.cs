using UnityEngine;
using UnityEngine.InputSystem;
using CameraSpace;

namespace PlayerSpace
{
    public class InputPlayerController : MonoBehaviour
    {
        private PlayerInput _playerInputController;
        private InputAction _actionMove;
        private CameraMovement _playerController;

        private void Awake()
        {
            _playerInputController = GetComponent<PlayerInput>();
            _actionMove = _playerInputController.actions["Move"];
            _playerController = GetComponent<CameraMovement>();
        }

        private void FixedUpdate()
        {
            Vector2 move = _actionMove.ReadValue<Vector2>();
            _playerController.MoveInput = move;
        }
    }
}