using UnityEngine;
using System.Collections;

public class KeyboardMouseInput : MonoBehaviour
{
    public Vector2 delta;
    public bool enableKeyboardControls;

    void Update()
    {
        if (enableKeyboardControls)
        {
            delta.x = (Input.GetAxis("Horizontal"));
            delta.y = (Input.GetAxis("Vertical"));

            if (Input.GetMouseButtonDown(0))
            {
                InputManager.instance.StartFiring();
            }

            if (Input.GetMouseButtonUp(0))
            {
                InputManager.instance.StopFiring();
            }

            if (Input.GetMouseButtonDown(1))
            {
                GameManager.instance.currentShip.GetComponent<ShipThrust>().speed = 20;
            }

            if (Input.GetMouseButtonUp(1))
            {
                GameManager.instance.currentShip.GetComponent<ShipThrust>().speed = 5;
            }
        }
    }
}
