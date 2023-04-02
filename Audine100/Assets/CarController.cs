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

    public Rigidbody2D rb;

    public float brakeForce = 5000f;
    private bool isBraking;

    public float speed = 100;
    private float movement;
    private float jumpingPower = 45f;

    private bool isJumping;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOverText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);

    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        //rb.freezeRotation = true;

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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a specific object
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOverText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            // Stop the game
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
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
        SceneManager.LoadScene("0");
    }

}
