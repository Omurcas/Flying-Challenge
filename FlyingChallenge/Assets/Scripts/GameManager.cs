using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector] public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private GameObject finishScreen;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void FinishText()
    {
        finishScreen.SetActive(true);
        finishText.text = "Congrats! Your score is " + score + " Press F to Restart!";
        
        
    }
   
}
