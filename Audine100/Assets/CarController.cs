using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public GameObject gameOverText;
    public GameObject button;
    public GameObject button1;

    public Rigidbody2D rb;

    public float brakeForce = 5000f;
    private bool isBraking;

    public float speed = 100;
    private float movement;
    private float jumpingPower = 50f;

    private bool isJumping;
    private bool isGrounded = true;

    private Text speedText;
    private Text scoreText;

    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);

        rb = GetComponent<Rigidbody2D>();
        gameOverText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);

        speedText = GameObject.Find("SpeedText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        //rb.freezeRotation = true;
        int audiSpeedLimit = 50;

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score;

        float currentSpeed = rb.velocity.magnitude * 3.6f;

        if (currentSpeed > audiSpeedLimit)
        {
            // if the car's speed is too high, set it to the maximum speed
            speed = audiSpeedLimit;
            currentSpeed = audiSpeedLimit;
        }


        if (speedText != null) // check if the speedText variable is not null
        {
            speedText.text = "Speed: " + Mathf.RoundToInt(currentSpeed) + " km/h";
        }

        if (Input.GetButtonDown("Jump") && isJumping == false && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isJumping = true;
            isGrounded = false;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            isBraking = true;
        }
        else
        {
            isBraking = false;
        }
    }

    private void FixedUpdate()
    {
        backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
        frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);

        if (isBraking)
        {
            rb.AddForce(-rb.velocity * brakeForce);
        }

        if (!isGrounded)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.freezeRotation = true;
            }
            else
            {
                rb.freezeRotation = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a specific object
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOverText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            button1.gameObject.SetActive(true);
            // Stop the game
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.freezeRotation = false;
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Points"))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        PlayerPrefs.SetInt("Score", score);

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = false;
        }
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
