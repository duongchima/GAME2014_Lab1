using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score = 5;
    public int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void AddScore()
    {
        currentScore += score;
    }
    public void DecreaseScore()
    {
        currentScore -= score;
    }
    public int GetScore()
    {
        return currentScore;
    }
}
