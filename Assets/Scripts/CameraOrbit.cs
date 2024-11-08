using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The center point of the cityscape
    public float distance = 20f; // Distance from the target
    public float rotationSpeed = 10f; // Speed of rotation

    private float currentAngle = 0f;

    void Update()
    {
        currentAngle += rotationSpeed * Time.deltaTime;

        float radians = currentAngle * Mathf.Deg2Rad;
        float x = target.position.x + Mathf.Cos(radians) * distance;
        float z = target.position.z + Mathf.Sin(radians) * distance;

        transform.position = new Vector3(x, transform.position.y, z);
        transform.LookAt(target);
    }
}
