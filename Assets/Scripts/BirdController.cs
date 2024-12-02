using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;
    private int Score;
    public int MaxScore;
    public Text ScoreText;
    public Text MaxScoreText;
    public GameObject gameOverPanel;
    void Start()
    {
        Time.timeScale = 1;
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        MaxScoreText.text = MaxScore.ToString();
    }
    void Update()
    {
        PlayerPrefs.GetInt("MaxScore", MaxScore);
        MaxScoreText.text = MaxScore.ToString();
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Score")
        {
            Score++;
            ScoreText.text = Score.ToString();
            if (Score >= MaxScore)
            {
                PlayerPrefs.SetInt("MaxScore", Score);
                PlayerPrefs.Save();
                MaxScore = Score;
                MaxScoreText.text = Score.ToString();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
