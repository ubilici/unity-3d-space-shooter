using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public float radius = 250.0f;
    public Rigidbody asteroidPrefab;
    public float spawnRate = 5.0f;
    public float variance = 1.0f;
    public Transform target;
    public bool spawnAsteroids = false;

    void Start()
    {
        StartCoroutine(CreateAsteroids());
    }

    void CreateNewAsteroid()
    {
        if (!spawnAsteroids)
        {
            return;
        }

        var asteroidPosition = Random.onUnitSphere * radius;

        asteroidPosition.Scale(transform.lossyScale);
        asteroidPosition += transform.position;

        var newAsteroid = Instantiate(asteroidPrefab);
        newAsteroid.transform.position = asteroidPosition;
        newAsteroid.transform.LookAt(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }

    public void DestroyAllAsteroids()
    {
        foreach (var asteroid in FindObjectsOfType<Asteroid>())
        {
            Destroy(asteroid.gameObject);
        }
    }

    IEnumerator CreateAsteroids()
    {
        while (true)
        {
            float nextSpawnTime = spawnRate + Random.Range(-variance, variance);

            yield return new WaitForSeconds(nextSpawnTime);

            yield return new WaitForFixedUpdate();

            CreateNewAsteroid();
        }
    }
}
