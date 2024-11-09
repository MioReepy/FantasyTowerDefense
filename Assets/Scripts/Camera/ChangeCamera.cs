using System;
using Cinemachine;
using PlayerSpace;
using UnityEngine;

namespace CameraSpace
{
    public class ChangeCamera : MonoBehaviour
    {
        #region Cameras

        [SerializeField] private CinemachineVirtualCamera[] _zoomCamera;
        [SerializeField] private CameraMovement _cameraMovement;

        private int currentZoomCameraIndex;

        #endregion

        private void Start()
        {
            InputPlayerController.Instance.OnZoomPlus += ZoomPlusCamera;
            InputPlayerController.Instance.OnZoomMinus += ZoomMinusCamera;
            
            currentZoomCameraIndex = 0;
            ResetCamera();
            _zoomCamera[currentZoomCameraIndex].enabled = true;
        }

        private void ZoomPlusCamera(object sender, EventArgs e)
        {
            if (currentZoomCameraIndex < _zoomCamera.Length - 1)
            {
                ResetCamera();
                currentZoomCameraIndex++;
                _zoomCamera[currentZoomCameraIndex].enabled = true;
                if (_zoomCamera[currentZoomCameraIndex].TryGetComponent(out Boundary boundary))
                {
                    _cameraMovement.boundary = boundary;
                }
            }
        }

        private void ZoomMinusCamera(object sender, EventArgs e)
        {
            if (currentZoomCameraIndex > 0)
            {
                ResetCamera();
                currentZoomCameraIndex--;
                _zoomCamera[currentZoomCameraIndex].enabled = true;
                _cameraMovement.boundary = _zoomCamera[currentZoomCameraIndex].GetComponent<Boundary>();
            }
        }

        private void ResetCamera()
        {
            foreach (var camera in _zoomCamera)
            {
                camera.enabled = false;
            }
        }

        private void OnDisable()
        {
            InputPlayerController.Instance.OnZoomPlus -= ZoomPlusCamera;
            InputPlayerController.Instance.OnZoomMinus -= ZoomMinusCamera;
        }
    }
}