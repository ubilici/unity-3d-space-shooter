using UnityEngine;
using System.Collections;

public class InputManager : Singleton<InputManager>
{
    public VirtualJoystick steering;
    public float fireRate = 0.2f;

    private ShipWeapons currentWeapons;
    private bool isFiring = false;

    public void SetWeapons(ShipWeapons weapons)
    {
        this.currentWeapons = weapons;
    }

    public void RemoveWeapons(ShipWeapons weapons)
    {
        if(this.currentWeapons == weapons)
        {
            this.currentWeapons = null;
        }
    }

    public void StartFiring()
    {
        StartCoroutine(FireWeapons());
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    IEnumerator FireWeapons()
    {
        isFiring = true;

        while (isFiring)
        {
            if(this.currentWeapons != null)
            {
                currentWeapons.Fire();
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
