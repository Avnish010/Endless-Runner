
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    [SerializeField] GameObject tObstaclePrefab;
    [SerializeField] float tChance = 0.2f;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
       
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

   public void SpawnObstacle()

    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random<tChance)
        {
            obstacleToSpawn = tObstaclePrefab;
        }
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnpoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstacleToSpawn, spawnpoint.position, Quaternion.identity, transform);
    }
    public GameObject coinPrefab;
   public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for(int i=0;i<coinsToSpawn;i++)
        {
          GameObject temp= Instantiate(coinPrefab,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if(point!=collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
