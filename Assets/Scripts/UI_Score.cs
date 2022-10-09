using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private PlayerBehaviour player;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return score;
    }
    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreLabel();
    }

    public void AddPoints(int pts)
    {
        score += pts;
        UpdateScoreLabel();
    }

    public void LosePonts(int pts)
    {
        score -= pts;
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        scoreText.text = $"Score: {score}";
    }
}
