using UnityEngine;
using System.Collections;

public class ShipThrust : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        Vector3 offset = Vector3.forward * Time.deltaTime * speed;
        transform.Translate(offset);
    }
}
