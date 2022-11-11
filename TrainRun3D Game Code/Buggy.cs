using UnityEngine;

public class Buggy : MonoBehaviour
{
    private Transform destination;
    public float updateSpeed = 800;
    public float currentDistance = 0;
    public float maxDistance = 0.5f;

    private void Awake()
    {
        destination = GameObject.FindWithTag("Player").transform;
    }
    void LateUpdate()
    {
        currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);
        transform.position = Vector3.MoveTowards(transform.position,
            destination.position + Vector3.up * currentDistance - destination.forward * (currentDistance + maxDistance * 0.5f),
            updateSpeed * Time.deltaTime);
        transform.LookAt(destination.transform);
    }
}
