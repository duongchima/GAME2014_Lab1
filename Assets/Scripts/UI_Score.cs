using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerBehaviour player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.score.ToString();
    }
}
