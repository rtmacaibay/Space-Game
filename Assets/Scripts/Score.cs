using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int player1_score;
    public int player2_score;
    public GameObject Player1;
    public GameObject Player2;
    //private bool isPlayer1Blinking;
    //private bool isPlayer2Blinking;

    // Start is called before the first frame update
    void Start()
    {
        player1_score = 0;
        player2_score = 0;
        //isPlayer1Blinking = false;
        //isPlayer2Blinking = false;
    }

    void Update()
    {
        if (!Player1.activeSelf)
        {
            //isPlayer1Blinking = true;
            player2_score += 1;
            Player1.SetActive(true);
            Player1.GetComponent<Ship>().canDie = true;
            //StartBlinking(Player2);
            UpdateScore();
        } else if (!Player2.activeSelf)
        {
            //isPlayer2Blinking = true;
            player1_score += 1;
            Player2.SetActive(true);
            Player2.GetComponent<Ship>().canDie = true;
            //StartBlinking(Player1);
            UpdateScore();
        }

        if (player1_score == 15)
        {
            SceneManager.LoadScene("Player1Win");
        } else if (player2_score == 15)
        {
            SceneManager.LoadScene("Player2Win");
        }
    }

    //private void StartBlinking(GameObject Ship)
    //{
    //    int blink = 0;
    //    while (blink < 5)
    //    {
    //        Ship.GetComponent<SpriteRenderer>().color = Color.black;
    //        _ = new WaitForSeconds(1f);
    //        Ship.GetComponent<SpriteRenderer>().color = Color.white;
    //        _ = new WaitForSeconds(1f);
    //        blink += 1;
    //    }
    //    Ship.GetComponent<Ship>().canDie = true;
    //    if (Ship.tag.Equals("Player1"))
    //    {
    //        isPlayer1Blinking = false;
    //    } else
    //    {
    //        isPlayer2Blinking = false;
    //    }
    //}

    private void UpdateScore()
    {
        string s = "Score: " + player1_score + " to " + player2_score;
        this.GetComponent<TMPro.TextMeshProUGUI>().SetText(s);
    }
}
