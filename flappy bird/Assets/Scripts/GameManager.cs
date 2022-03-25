using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameActive = false;
    public GameObject player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public Button restartButton;
    public Button startButton;
    public GameObject obstacle;
    public float obstacleSpawnPosX = 0;
    private float obstacleSpawnPosY;
    public float spawnIntervalMax = 1f;
    public float spawnIntervalMin = 0.5f;
    private float spawnInterval;
    private float spawnDelay = 1f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, RandomSpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    //reload scene when restart button is pressed
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        isGameActive = true;
        player.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        UpdateScore(0);
    }
    void SpawnObstacle()
    {
        if (isGameActive)
        {
            Instantiate(obstacle, GenerateObstacleSpawnPos(), obstacle.transform.rotation);
        }
        
    }

    float RandomSpawnInterval()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

        return spawnInterval;
    }
    
    Vector2 GenerateObstacleSpawnPos()
    {
        obstacleSpawnPosY = Random.Range(-7f,-4.5f);

        Vector2 spawnPos = new Vector2(obstacleSpawnPosX, obstacleSpawnPosY);

        return spawnPos;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
