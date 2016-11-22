using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    public GameObject shipPrefab;
    public Transform shipStartPosition;
    public GameObject currentShip { get; private set; }

    public GameObject spaceStationPrefab;
    public Transform spaceStationStartPosition;
    public GameObject currentSpaceStation { get; private set; }

    public SmoothFollow cameraFollow;

    public GameObject inGameUI;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject mainMenu;

    public bool gameIsPlaying { get; private set; }

    public AsteroidSpawner asteroidSpawner;

    public bool paused;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowUI(GameObject newUI)
    {
        GameObject[] allUI = { inGameUI, pauseMenu, gameOverMenu, mainMenu };

        foreach (GameObject UIToHide in allUI)
        {
            UIToHide.SetActive(false);
        }

        newUI.SetActive(true);
    }

    public void ShowMainMenu()
    {
        ShowUI(mainMenu);

        gameIsPlaying = false;
        asteroidSpawner.spawnAsteroids = false;
    }

    public void StartGame()
    {
        ShowUI(inGameUI);
        gameIsPlaying = true;

        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        if(currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        currentShip = Instantiate(shipPrefab);
        currentShip.transform.position = shipStartPosition.position;
        currentShip.transform.rotation = shipStartPosition.rotation;

        currentSpaceStation = Instantiate(spaceStationPrefab);
        currentSpaceStation.transform.position = spaceStationStartPosition.position;
        currentSpaceStation.transform.rotation = spaceStationStartPosition.rotation;

        cameraFollow.target = currentShip.transform;

        asteroidSpawner.spawnAsteroids = true;
        asteroidSpawner.target = currentSpaceStation.transform;
    }

    public void GameOver()
    {
        ShowUI(gameOverMenu);
        gameIsPlaying = false;

        if(currentShip != null)
        {
            Destroy(currentShip);
        }

        if(currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        asteroidSpawner.spawnAsteroids = false;
        asteroidSpawner.DestroyAllAsteroids();
    }

    public void SetPaused(bool paused)
    {
        inGameUI.SetActive(!paused);
        pauseMenu.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

}
