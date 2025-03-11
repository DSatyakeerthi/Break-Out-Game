using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class bouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    Rigidbody2D rb2d;

    int score = 0;
    int lives = 5;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;

    public GameObject gameOverPanel;

    public AudioSource scoreAudioSource; // Reference to the AudioSource
    public AudioClip scoreSound;

    public AudioSource lifeAudioSource; // Reference to the AudioSource
    public AudioClip lifeSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if(lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb2d.linearVelocity = Vector3.zero;
                lives--;
                livesImage[lives].SetActive(false);
                if (lifeAudioSource != null && lifeSound != null)
                {
                    lifeAudioSource.PlayOneShot(lifeSound); // Play the sound
                }
            }
            

        }

        if(rb2d.linearVelocity.magnitude > maxVelocity)
        {
            rb2d.linearVelocity = Vector3.ClampMagnitude(rb2d.linearVelocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreTxt.text = score.ToString("00000");
            if (scoreAudioSource != null && scoreSound != null)
            {
                scoreAudioSource.PlayOneShot(scoreSound); // Play the sound
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game over!");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
