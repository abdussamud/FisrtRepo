using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    public float pitch = 2f, currentZoom = 10f;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}