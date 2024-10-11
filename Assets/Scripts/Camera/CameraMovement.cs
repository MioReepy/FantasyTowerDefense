using UnityEngine;

namespace CameraSpace
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Boundary _boundary;
        [SerializeField] private float _cameraSpeed;
        [SerializeField] internal float _cameraScrollY;
        [SerializeField] private float _scrollSpeed;
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
            MoveCamera();
        }

        private void MoveCamera()
        {
            Vector3 movePosition = transform.position + _moveInput;
            movePosition.y -= _cameraScrollY * _scrollSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(Mathf.Clamp(movePosition.x, _boundary.xMin, _boundary.xMax), 
                    Mathf.Clamp(movePosition.y, _boundary.yMin, _boundary.yMax),
                    Mathf.Clamp(movePosition.z, _boundary.zMin, _boundary.zMax)), _cameraSpeed * Time.fixedDeltaTime);
        }
    }
}