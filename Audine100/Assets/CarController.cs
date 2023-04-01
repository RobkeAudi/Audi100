using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float brakeForce = 5000f;
    private bool isBraking;
    public float speed = 100;
    private float jumpingPower = 45f;
   
    private float movement;
    public GameObject gameOverText;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;
    private float groundCheckRadius = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal");

        rb.freezeRotation = true;

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
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
            // Stop the game
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(-rb.velocity.normalized * 10f, ForceMode2D.Impulse);
        }
    }

}
