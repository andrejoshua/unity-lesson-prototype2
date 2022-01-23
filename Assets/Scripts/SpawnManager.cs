using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] animals;

    private const float spawnRangeX = 10.0f;
    private const float spawnDelay = 2.0f;
    private const float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnRandomAnimal()
    {
        var randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, transform.position.z);

        var randomIndex = Random.Range(0, animals.Length);
        var randomAnimal = animals[randomIndex];
        Instantiate(randomAnimal, randomPosition, transform.rotation);
    }
}