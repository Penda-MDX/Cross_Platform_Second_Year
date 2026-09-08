using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnScoreChanged;
    public event EventHandler OnDeath;
    private int lives;
    private int score;
    private int remainingAsteroids;
    [SerializeField] private int startingAsteroids;
    [SerializeField] private int asteroidsFragments;
    private int levelNumber;



    [SerializeField] private Transform playerShipPrefab;
    [SerializeField] private Transform largeAsteroidPrefab;
    [SerializeField] private Transform mediumAsteroidPrefab;
    [SerializeField] private Transform smallAsteroidPrefab;

    private Transform playerShipObject;

    private float difficultySpeed;

    private float difficultySpeedIncrement;

    private bool respawn;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        score = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        CheckRespawnPlayerShip();

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            InitialiseGame();
        }
    }

    public void InitialiseGame()
    {

        GameObject[] CurrentAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroidal in CurrentAsteroids)
        {
            Destroy(asteroidal);
        }

        if (playerShipObject != null)
        {
            Destroy(playerShipObject);
        }

        //reset lives to 3 
        lives = 3;
        OnDeath?.Invoke(this, EventArgs.Empty);
        respawn = true;
        //load up data for all levels?
        remainingAsteroids = startingAsteroids;


        //create current level data handler? and populate
        SpawnNewAsteroids(startingAsteroids);

    }

    public void StartLevel()
    {
        //get the next level

    }

    public void CheckLevelComplete()
    {
        if (remainingAsteroids <= 0)
        {
            //where do I get new level data from?

            //increment current level 
            levelNumber++;

            //set the level data

            //trigger end of level message and delay

        }
    }

    public void CheckRespawnPlayerShip()
    {
        if (lives > 0 && respawn)
        {
            playerShipObject = Instantiate(playerShipPrefab, Vector3.zero, Quaternion.identity);
            respawn = false;
        }
        else
        {
            //Go back to start

        }
    }

    public void SpawnNewAsteroids(int NumberofAsteroids)
    {
        for (int i = 1; i <= NumberofAsteroids; i++)
        {
            Vector3 spawnV3 = Vector3.zero;

            if (UnityEngine.Random.Range(-1, 1) > 0)
            {
                spawnV3.x = UnityEngine.Random.Range(2, 8);
            }
            else
            {
                spawnV3.x = UnityEngine.Random.Range(-8, -2);
            }

            if (UnityEngine.Random.Range(-1, 1) > 0)
            {
                spawnV3.y = UnityEngine.Random.Range(2, 8);
            }
            else
            {
                spawnV3.y = UnityEngine.Random.Range(-8, -2);
            }
            //Debug.Log(spawnV3);

            Instantiate(largeAsteroidPrefab, spawnV3, Quaternion.identity);
        }
    }

    public void DestroyAsteroid(AsteroidControl asteroidController)
    {
        Vector2 asteroidPosition = asteroidController.gameObject.transform.position;
        string state = asteroidController.GetAsteroidState();
        AddScore(100);
        switch (state)
        {
            case "Large":
                Debug.Log("Large to Medium");
                for(int i = 0; i< asteroidsFragments; i++)
                {
                    Vector3 newPosition = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), 0);
                    newPosition.x += asteroidPosition.x;
                    newPosition.y += asteroidPosition.y;

                    Instantiate(mediumAsteroidPrefab, newPosition, Quaternion.identity);
                }
                Destroy(asteroidController.gameObject);
                break;
            case "Medium":
                Debug.Log("Medium to Small");
                for (int i = 0; i < asteroidsFragments; i++)
                {
                    Vector3 newPosition = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), 0);
                    newPosition.x += asteroidPosition.x;
                    newPosition.y += asteroidPosition.y;
                    Instantiate(smallAsteroidPrefab, newPosition, Quaternion.identity);
                }
                Destroy(asteroidController.gameObject);
                break;
            case "Small":
                Debug.Log("Small");
                Destroy(asteroidController.gameObject);
                break;
        }
    }



    public void PlayerShipDeath(ShipControl shipController)
    {
        if (respawn)
        {
            return;
        }
        //Debug.Log("Death");
        Destroy(shipController.gameObject);
        lives--;
        respawn = true;
        OnDeath?.Invoke(this, EventArgs.Empty);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetLives()
    {
        return lives;
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }
}
