using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //acceso al scencemanager para poder acceder al metodo de restart
using TMPro; //para el tiempo transcurido en pantalla

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    //variables para el timerdeljuego
    private int score;
    private float timer; 
    public static GameManager Instance {get; private set;}
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void ShowGameOverScreen(){ //QUE APAREZCA EL SCREEN DE GAME OVER
        gameOverScreen.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSeconds = 10;

        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);
        scoreText.text = string.Format("{0:00000}", score);
    }
}
