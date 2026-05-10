using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtenstion = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = .2f;
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    const string playerString = "Player";

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            if (!gameManager.GameOver)
            {
                gameManager.IncreaseTime(checkpointTimeExtenstion);
                
            }
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
        }
    }
}
