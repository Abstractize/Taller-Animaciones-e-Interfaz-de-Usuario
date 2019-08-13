using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    //Text
    public Text Score;
    public Text Lives;
    public Text Coins;
    public Text Time;
    //Values
    float timeLeft = 300.0f;
    //Components
    MovementController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= player.Timer;
        Score.text = "Score: " + player.Score;
        Lives.text = "Lives: " + player.Lives;
        Coins.text = "Coins: " + player.Coins;
        Time.text = "Time: " + timeLeft.ToString();
    }
}
