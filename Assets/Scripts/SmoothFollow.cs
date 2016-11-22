using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float height = 5.0f;
    public float distance = 10.0f;

    public float rotationDamping;
    public float heightDamping;

    void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        // Damp the rotation arround the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);
    }
}
