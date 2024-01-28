using UnityEngine;

public class KeepAbove : MonoBehaviour
{
    [SerializeField] private Rigidbody Parent;

    void FixedUpdate()
    {
        transform.position = Parent.position + Vector3.up;
    }
}
