using UnityEngine;

public class UseGravitation : MonoBehaviour
{
    [SerializeField] private float gravitationForce = 100f;
    private void OnCollisionStay(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gravitationForce);
        Debug.Log(other.gameObject.name);
    }
}
