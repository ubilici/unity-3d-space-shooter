using UnityEngine;
using System.Collections;

public class DamageTaking : MonoBehaviour
{
    public int hitPoints = 10;
    public GameObject destrucitonPrefab;
    public bool gameOverOnDestroyed = false;

    public void TakeDamage(int amount)
    {
        Debug.Log(gameObject.name + " damaged!");
        hitPoints -= amount;

        if (hitPoints <= 0)
        {
            Debug.Log(gameObject.name + " destroyed!");
            if(destrucitonPrefab != null)
            {
                Instantiate(destrucitonPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}