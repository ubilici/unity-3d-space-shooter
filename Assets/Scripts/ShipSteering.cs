﻿using UnityEngine;
using System.Collections;

public class ShipSteering : MonoBehaviour
{
    public float turnRate = 6.0f;
    public float levelDamping = 1.0f;

    void Update()
    {
        var steeringInput = InputManager.instance.steering.delta;

        var rotation = new Vector2();

        rotation.y = steeringInput.x;
        rotation.x = steeringInput.y * -1.0f;

        rotation *= turnRate;
        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);

        var newOrientation = Quaternion.Euler(rotation);
        transform.rotation *= newOrientation;

        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation, levelDamping * Time.deltaTime);
    }
}