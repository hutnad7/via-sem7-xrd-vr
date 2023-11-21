using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MutantSpawner : MonoBehaviour
{
    public GameObject mutantPrefab;

    public GameObject Player;
    public Transform[] spawnPoints;
    public float spawnInterval = 10f;

    void Start()
    {
        StartCoroutine(SpawnMutants());
    }

    IEnumerator SpawnMutants()
    {
        while (PlayScript.isPlaying)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (PlayScript.isPlaying)
            {
                Transform randomSpawnPoint = GetRandomSpawnPoint();
                GameObject newMutant = Instantiate(randomSpawnPoint.gameObject, randomSpawnPoint.position, Quaternion.identity);
                StalkerAI stalkerAI = newMutant.GetComponent<StalkerAI>();
                stalkerAI.StalkerDest = Player;
            }
        }
    }

    Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
