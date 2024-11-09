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
        private InputAction _unSelect;
        private InputAction _zoomPlus;
        private InputAction _zoomMinus;
        private CameraMovement _playerController;
        public static InputPlayerController Instance;
        public event EventHandler OnUnselect;
        public event EventHandler OnZoomPlus;
        public event EventHandler OnZoomMinus;

        private void Awake()
        {
            Instance = this;
            
            _playerInputController = GetComponent<PlayerInput>();
            
            _actionMove = _playerInputController.actions["Move"];
            _unSelect = _playerInputController.actions["Unselect"];
            _zoomPlus = _playerInputController.actions["ZoomPlus"];
            _zoomMinus = _playerInputController.actions["ZoomMinus"];
            
            _playerController = GetComponent<CameraMovement>();
        }

        private void OnEnable()
        {
            _unSelect.performed += _ => Unselect();
            _zoomPlus.performed += _ => ZoomPlus();
            _zoomMinus.performed += _ => ZoomMinus();
        }

        private void FixedUpdate()
        {
            Vector2 move = _actionMove.ReadValue<Vector2>();
            _playerController.MoveInput = move;
        }

        private void Unselect()
        {
            OnUnselect?.Invoke(this, EventArgs.Empty);
        }

        private void ZoomPlus()
        {
            OnZoomPlus?.Invoke(this, EventArgs.Empty);
        }

        private void ZoomMinus()
        {
            OnZoomMinus?.Invoke(this, EventArgs.Empty);
        }
    }
}