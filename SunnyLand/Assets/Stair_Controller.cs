using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair_Controller : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private Rigidbody2D rb;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        speed = player.GetComponent<Player_Controller>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.UpArrow) && collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsCrouching", false);
            animator.SetBool("IsClimbing", true);
            animator.SetBool("OnStair", false);
            rb.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsClimbing", true);
            animator.SetBool("OnStair", false);
            rb.velocity = new Vector2(0, -speed);
        }
        else if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsClimbing", false);
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsCrouching", false);
            animator.SetBool("OnStair", true);
            rb.velocity = new Vector2(0, 0.2f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsCrouching", false);
            animator.SetBool("IsClimbing", false);
            animator.SetBool("OnStair", false);
        }
    }
}
