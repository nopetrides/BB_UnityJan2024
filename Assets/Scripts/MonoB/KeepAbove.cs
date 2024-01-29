using UnityEngine;

public class KeepAbove : MonoBehaviour
{
    [SerializeField] private Rigidbody Parent;

    private void FixedUpdate()
    {
        transform.position = Parent.position + Vector3.up;
    }
}