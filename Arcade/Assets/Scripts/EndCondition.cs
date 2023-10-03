using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCondition : MonoBehaviour
{
    public GameObject player2Win;
    public GameObject player1Win;

    private void Start()
    {
        player1Win.SetActive(false);
        player2Win.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player1"))
        {
            player2Win.SetActive(true);
        }

        if (other.CompareTag("Player2"))
        {
            player1Win.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
    }

}
