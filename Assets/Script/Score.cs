using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreCount;
    public static Score instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
    }

    public void AddScore(int point)
    {
        scoreCount += point;
        scoreText.text = "Score: " + scoreCount;
    }
}

