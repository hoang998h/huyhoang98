using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private PolygonCollider2D collider_idle;
    private PolygonCollider2D collider_crouch;
    private Animator animator;
    public AudioSource Jumpaudio;
    public AudioSource BGaudio;
    public AudioSource Deathaudio;
    private Crouch_Check crouch_Check;
    private float HorizontalMove;
    private float VerticalMove;
    public float speed;
    public float jumpForce;
    private bool isGrounded;
    private bool check;
    [SerializeField]
    private PolygonCollider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        crouch_Check = FindObjectOfType<Crouch_Check>();
        colliders[0].enabled = true;
        colliders[1].enabled = false;
        GameObject.Find("Crouch_Check").SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        check = crouch_Check.Stand();
        Walk();
        Jump();
        Crouch();
    }
    void Walk()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(HorizontalMove * speed, rb.velocity.y);
        Flip();
    }
    void Flip()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            animator.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
    void Jump()
    {
        if (check == true)
        {
            if (rb.velocity.y < 0)
            {
                animator.SetBool("IsJumping", false);
            }
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                Jumpaudio.Play();
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsFalling", true);
                isGrounded = false;
            }
        }
    }
    void Crouch()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (animator.GetBool("IsClimbing") == false)
                {
                    colliders[0].enabled = false;
                    colliders[1].enabled = true;
                    animator.SetBool("IsCrouching", true);
                    if (GameObject.Find("Crouch_Check") != null)
                    {
                        GameObject.Find("Crouch_Check").SetActive(true);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (check == true)
                {
                    colliders[0].enabled = true;
                    colliders[1].enabled = false;
                    animator.SetBool("IsCrouching", false);
                    if (GameObject.Find("Crouch_Check") != null)
                    {
                        GameObject.Find("Crouch_Check").SetActive(false);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tile" || collision.gameObject.tag == "FallingTile")
        {
            animator.SetBool("IsFalling", false);
            isGrounded = true;
        }
        if (collision.gameObject.tag == "GameBorder")
        {

            Deathaudio.Play();
            BGaudio.Stop();
            animator.SetBool("IsHurt", true);
        }
        if (collision.gameObject.tag == "GameBorder")
        {

            Deathaudio.Play();
            BGaudio.Stop();
            animator.SetBool("IsHurt", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "FallingTile")
        {
            isGrounded = false;
        }
        
    }
}
