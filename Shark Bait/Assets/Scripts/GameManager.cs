using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text score;
    public Image loseScreen;
    public int _playerScore;
    public EventTrigger.TriggerEvent CoinScore;
    public Transform[] CSpawnPointsLibrary;
    public Coin coinPrefab; 
    private Coin currentCoin;
    private int thresholdCount; // Gives a score threshold for the tilt to occur at 5 point intervals

    private void OnEnable()
    {
        GameEvents.CoinScore += CoinSpawn;
        GameEvents.CoinEat += CoinEaten;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= CoinSpawn;
        GameEvents.CoinEat += CoinEaten;
    }


    public void RestartGame()
    {
        // restarts game w/ the reset button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CoinSpawn()
    {
        //Pick a random interger from the library then store that transform position
        int randomInt = Random.Range(0, CSpawnPointsLibrary.Length); 
        Vector3 randomPosition = CSpawnPointsLibrary[randomInt].position;

        //Use that transform position to clone a prefab coin to 
        currentCoin = Instantiate(coinPrefab);
        currentCoin.transform.position = randomPosition;

        //Give the player a point
        _playerScore++;
        thresholdCount++;
        this.score.text = _playerScore.ToString();
        Debug.Log("score");
    }
    public void CoinEaten()
    {
        //Pick a random interger from the library then store that transform position
        int randomInt = Random.Range(0, CSpawnPointsLibrary.Length);
        Vector3 randomPosition = CSpawnPointsLibrary[randomInt].position;

        //Use that transform position to clone a prefab coin to 
        currentCoin = Instantiate(coinPrefab);
        currentCoin.transform.position = randomPosition;
    }
    private void Update()
    {
     //secret points that will move the platform every 5 points then reset
        if (thresholdCount == 5)
        {
            //GameEvents.platformTiltTrigger.Invoke();
            thresholdCount = 0;
            Debug.Log("tilt");
        }
        
    }
}
