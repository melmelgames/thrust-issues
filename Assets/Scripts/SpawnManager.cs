using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] collectablesArray;
    public GameObject healthItem;
    public GameObject powerUp;
    public Transform collectablesSpawnPos;
    public GameObject tutorialWindow;

    public GameObject flashAlert;
    public AudioClip flashSound;
    public GameObject[] obstaclesArray;
    public Transform obstaclesSpawnPos;
    private float spawnTime;
    private float currentTime;
    [SerializeField] private float timeBetweenSpawns;

    private void Start()
    {
        currentTime = 0.0f;
        spawnTime = 0.0f;
    }
    void Update()
    {
        if (!tutorialWindow.activeSelf)
        {
            StartCoroutine(SpawnObstacle());
            StartCoroutine(SpawnCollectable());
            StartCoroutine(SpawnHealthItem());
            StartCoroutine(SpawnPowerUp());
        }
        
    }

    private IEnumerator SpawnCollectable()
    {
        yield return new WaitForSeconds(1.0f);
        int rdnIndex = Random.Range(0, collectablesArray.Length);
        float rdnX = Random.Range(-10.0f, 10.0f);
        int collectableCount = FindObjectsOfType<Collectable>().Length;
        if(collectableCount < 4 && !tutorialWindow.activeSelf)
        {
            int rdnNum = Random.Range(1, 11);
            switch (rdnNum)
            {
                case 1:
                    ///// Instantiate 1 asteroid (or a series of up to 3 at random intervals)
                    int rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(collectablesArray[rdnIndex], new Vector3(rdnX, collectablesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 2:
                    ///// Instantiate 2 asteroids side by side in a inverted ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x + 3.0f, collectablesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x - 3.0f, collectablesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 3:
                    ///// Instantiate 2 asteroids side by side in a ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x + 3.0f, collectablesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x - 3.0f, collectablesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 4:
                    ///// Instantiate 2 asteroids side by side in a line
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x + 3.0f, collectablesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x - 3.0f, collectablesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 5:
                    // Instantiate 5 asteroids side by side in a inverted ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x, collectablesSpawnPos.position.y - 4.0f, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x + 3.0f, collectablesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x - 3.0f, collectablesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x + 6.0f, collectablesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(collectablesArray[rdnIndex], new Vector3(collectablesSpawnPos.position.x - 6.0f, collectablesSpawnPos.position.y - 8.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
            }
        }

        
    }
    private IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(1.0f);
        float rdnX = Random.Range(-10.0f, 10.0f);
        int powerupCount = FindObjectsOfType<PowerUp>().Length;
        int obstacleCount = FindObjectsOfType<Obstacle>().Length;
        if (powerupCount == 0 && !tutorialWindow.activeSelf && obstacleCount > 0)
        {
            Instantiate(powerUp, new Vector3(rdnX, collectablesSpawnPos.position.y, 0.0f), Quaternion.identity);
        }
    }
    private IEnumerator SpawnHealthItem()
    {
        yield return new WaitForSeconds(1.0f);
        float rdnX = Random.Range(-10.0f, 10.0f);
        int healthItemCount = FindObjectsOfType<HealthItem>().Length;
        if (healthItemCount == 0 && !tutorialWindow.activeSelf && Health.GetHealth() < Health.GetMaxHealth())
        {
            Instantiate(healthItem, new Vector3(rdnX, collectablesSpawnPos.position.y, 0.0f), Quaternion.identity);
        }
    }

    private IEnumerator SpawnObstacle()
    {
        currentTime = Time.time;
        flashAlert.GetComponent<Animator>().SetBool("alertOn", false);
        yield return new WaitForSeconds(10.0f);
        int obstacleCount = FindObjectsOfType<Obstacle>().Length;
        if (obstacleCount == 0 && currentTime - spawnTime > timeBetweenSpawns)
        {
            spawnTime = Time.time;
            flashAlert.GetComponent<Animator>().SetBool("alertOn", true);
            AudioManager.PlaySound(flashSound);
            int rdnIndex = Random.Range(0, obstaclesArray.Length);
            float rdnX = Random.Range(-10.0f, 10.0f);
            int rdnNum = Random.Range(1, 11);
            switch (rdnNum)
            {
                case 1:
                    ///// Instantiate 1 asteroid (or a series of up to 3 at random intervals)
                    int rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(rdnX, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 2:
                    ///// Instantiate 2 asteroids side by side in a inverted ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 3.0f, obstaclesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 3.0f, obstaclesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 3:
                    ///// Instantiate 2 asteroids side by side in a ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 3.0f, obstaclesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 3.0f, obstaclesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 4:
                    ///// Instantiate 2 asteroids side by side in a line
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 3.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 3.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 5:
                    // Instantiate 3 asteroids side by side in a inverted ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x, obstaclesSpawnPos.position.y - 4.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 6.0f, obstaclesSpawnPos.position.y - 8.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 6:
                    // Instantiate 3 asteroids side by side in a ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x, obstaclesSpawnPos.position.y - 4.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 6.0f, obstaclesSpawnPos.position.y - 8.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 7:
                    // Instantiate 3 asteroids side by side in a line
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 8:
                    // Instantiate 5 asteroids side by side in a inverted ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x, obstaclesSpawnPos.position.y - 4.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 3.0f, obstaclesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 3.0f, obstaclesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 6.0f, obstaclesSpawnPos.position.y - 8.0f, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 9:
                    // Instantiate 5 asteroids side by side in a ladder
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x, obstaclesSpawnPos.position.y - 4.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 3.0f, obstaclesSpawnPos.position.y - 6.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 3.0f, obstaclesSpawnPos.position.y - 2.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 6.0f, obstaclesSpawnPos.position.y - 8.0f, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
                case 10:
                    // Instantiate 5 asteroids side by side in a line
                    rdnSpwNbr = Random.Range(1, 4);
                    for (int i = 0; i < rdnSpwNbr; i++)
                    {
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 3.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 3.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x + 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        Instantiate(obstaclesArray[rdnIndex], new Vector3(obstaclesSpawnPos.position.x - 6.0f, obstaclesSpawnPos.position.y, 0.0f), Quaternion.identity);
                        float rdnTime = Random.Range(0.5f, 1.5f);
                        yield return new WaitForSeconds(rdnTime);
                    }
                    break;
            }
        }
    }
}
