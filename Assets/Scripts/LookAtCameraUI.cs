using UnityEngine;

namespace UISpace
{
    public class LookAtCameraUI : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}