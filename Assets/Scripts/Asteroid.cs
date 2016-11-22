using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        var indicator = IndicatorManager.instance.AddIndicator(gameObject, Color.red);
    }
}
