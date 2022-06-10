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

    private void OnEnable()
    {
        GameEvents.CoinScore += PlayerScores;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= PlayerScores;
    }
    public void PlayerScores(Coin playerScores)
    {
        _playerScore ++;
        this.score.text = _playerScore.ToString();
        Debug.Log("score");
    }
    public void RestartGame()
    {
        // restarts game w/ the reset button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
