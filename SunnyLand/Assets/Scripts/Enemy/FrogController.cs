using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float MoveSpeed = 4f, JumpSpeed = 7f,LastPosX;

    private Rigidbody2D body;
    private SpriteRenderer sr;
    private Animator anim;

    private Vector3 FirstPos;

    private float dirX;
    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        dirX = 1f;
        StartCoroutine(Moving());

    }
    
    void Awake()
    {
        //bat dau la di chuyen tu phai sang trai
        FirstPos = transform.position;
        LastPosX = FirstPos.x - 13f;
        Debug.Log(FirstPos.x + "," + LastPosX);
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= FirstPos.x || transform.position.x <= LastPosX)
        {
            dirX = -dirX;
        }
        CheckAnimation();

    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(5f);

        if (isGrounded)
        {
            body.velocity = new Vector2(dirX*MoveSpeed, JumpSpeed);
            isGrounded = false;
            Flip();
        }

        StartCoroutine(Moving());
        
    }

    void CheckAnimation()
    {
        if (body.velocity.y > 0)
        {
            anim.SetBool("Jumping", true);
        }
        if (body.velocity.y < 0)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
    }

    void Flip()
    {
        if (dirX > 0)
            sr.flipX = true;
        else
            sr.flipX = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            isGrounded = true;
            anim.SetBool("Falling", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            isGrounded = false;
        }
    }
}
