using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum_Controller : MonoBehaviour
{
    public float speed;
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        Vector2 enemy_position = transform.position;
        enemy_position.x -= speed * Time.deltaTime;
        transform.position = enemy_position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="GameBorder")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
