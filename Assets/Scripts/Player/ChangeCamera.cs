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
            ResetCamera();

            if (currentZoomCameraIndex != _zoomCamera.Length)
            {
                currentZoomCameraIndex++;
            }

            _zoomCamera[currentZoomCameraIndex].enabled = true;
        }

        private void ZoomMinusCamera(object sender, EventArgs e)
        {
            ResetCamera();

            if (currentZoomCameraIndex != 0)
            {
                currentZoomCameraIndex--;
            }

            _zoomCamera[currentZoomCameraIndex].enabled = true;
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
            InputPlayerController.Instance.OnZoomPlus += ZoomPlusCamera;
            InputPlayerController.Instance.OnZoomMinus += ZoomMinusCamera;

        }
    }
}