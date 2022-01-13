using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
      groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit (Collider other)
    {
      groundSpawner.SpawnTile(true);
      Destroy(gameObject, 2);
    }

    public void SpawnObstacle() 
    {
      bool inGameMode = GameManager.GetInstance().currentGameState == GameState.InGame;

      if(inGameMode)
      {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefabs, spawnPoint.position, Quaternion.identity, transform);
      }
    }
}
