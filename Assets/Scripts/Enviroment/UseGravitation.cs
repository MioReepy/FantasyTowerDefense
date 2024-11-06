using UnityEngine;

public class UseGravitation : MonoBehaviour
{
    [SerializeField] private bool _isUseGravitation = false;
    [SerializeField] private float _gravitationForce = 100f;
    
    private void OnCollisionStay(Collision other)
    {
        if (_isUseGravitation)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _gravitationForce);
        }
    }
}
