using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Bola")]
    public GameObject ball;

    [Header("PlayerIzquierda")]
    public GameObject player1;
    public GameObject player1Goal;

    [Header("PlayerDerecha")]
    public GameObject player2;
    public GameObject player2Goal;

    [Header("TextBox")]
    public Text player1Text;
    public Text player2Text;

    [Header("Arcos")]
    private int player1Score = 0;
    private int player2Score = 0;

    //compruebo si estoy jugando con la IA
    public bool IAGame;

    public int maxScore = 3;

    public void Player1Score()
    {
        if (IAGame)
        {
            player1Score = player1Score + 1;
            player1Text.text = player1Score.ToString();
            player2.GetComponent<IA>().speed += 0.75f;
            CheckVictory();
            ResetPosition();
        }
        else
        {
            player1Score++;
            player1Text.text = player1Score.ToString();
            CheckVictory();
            ResetPosition();
        }

    }

    public void Player2Score()
    {
        player2Score++;
        player2Text.text = player2Score.ToString();
        CheckVictory();
        ResetPosition();
    }

    private void ResetPosition()
    {
        if (IAGame)
        {
            ball.GetComponent<Ball>().Reset();
            player1.GetComponent<PlayerController>().Reset();
        }
        else
        {
            ball.GetComponent<Ball>().Reset();
            player1.GetComponent<PlayerController>().Reset();
            player2.GetComponent<PlayerController>().Reset();
        }
    }

    public void CheckVictory()
    {
        if (player1Score >= maxScore)
        {
            SceneManager.LoadScene("VictoryPlayer1");
        }
        if (player2Score >= maxScore)
        {
            SceneManager.LoadScene("VictoryPlayer2");

        }
    }


}
