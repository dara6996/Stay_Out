using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private int score;
    public static GameManagerScript S;
    
    void Awake()
    {
        S = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 20)
        {
            GameWinner();
        }
    }
    
    public void IncreaseScore() { //switched from private to public to allow HoleScript use of this function - 13th mistake found
        score++;
    }

    public void GameOver()
    {
        //GameOver
        SceneManager.LoadScene("GameOver");
    }
    
    public void GameWinner()
    {
        //GameOver
        SceneManager.LoadScene("GameWinner");
    }
}
