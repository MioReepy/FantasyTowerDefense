using System;
using UnityEngine;
using UnityEngine.InputSystem;
using CameraSpace;

namespace PlayerSpace
{
    public class InputPlayerController : MonoBehaviour
    {
        private PlayerInput _playerInputController;
        
        private InputAction _actionMove;
        private InputAction _scrollMove;
        private InputAction _mouseClick;
        
        private CameraMovement _playerController;

        public static InputPlayerController Instance;
        
        public event EventHandler OnClick;

        private void Awake()
        {
            Instance = this;
            
            _playerInputController = GetComponent<PlayerInput>();
            
            _actionMove = _playerInputController.actions["Move"];
            _scrollMove = _playerInputController.actions["MouseScrollY"];
            _scrollMove = _playerInputController.actions["MouseScrollY"];
            _mouseClick = _playerInputController.actions["MouseClick"];
            
            _playerController = GetComponent<CameraMovement>();
        }

        private void OnEnable()
        {
            _mouseClick.performed += _ => MouseClick();
        }

        private void FixedUpdate()
        {
            Vector2 move = _actionMove.ReadValue<Vector2>();
            _playerController.MoveInput = move;
            _playerController._cameraScrollY = _scrollMove.ReadValue<float>();
        }

        private void MouseClick()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}