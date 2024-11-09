using UnityEngine;

namespace CameraSpace
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed;
        internal Boundary boundary;
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
            if (boundary != null)
            {
                Vector3 movePosition = transform.position + _moveInput;
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(Mathf.Clamp(movePosition.x, boundary.xMin, boundary.xMax), transform.position.y,
                        Mathf.Clamp(movePosition.z, boundary.zMin, boundary.zMax)), _cameraSpeed * Time.fixedDeltaTime);
            }
        }
    }
}