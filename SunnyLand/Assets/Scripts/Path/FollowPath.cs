using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public PathDefinition path;
    public float speed;
    private Transform targetPoint;
    public bool PlayerOnTile;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (path == null)
            return;
        targetPoint = path.getPointAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        var distanceTarget = Vector2.Distance(transform.position,targetPoint.position);
        if(distanceTarget < 0.1f)
        {
            targetPoint = path.getNextPoint();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "GameBorder")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag =="Player")
        {
            PlayerOnTile = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOnTile = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerOnTile == true)
        {
            if (collision.gameObject.tag == "DropTile")
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
