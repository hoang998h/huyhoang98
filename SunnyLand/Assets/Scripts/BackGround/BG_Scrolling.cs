using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scrolling : MonoBehaviour
{
    public float ScrollSpeed;
    private float Move;
    private Material mt;
    private Vector2 offset = Vector2.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        mt = GetComponent<Renderer>().material;
    }
    void Start()
    {
        offset = mt.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            Move =GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x;
            if (Move > 0)
            {
                offset.x += ScrollSpeed * Time.deltaTime;
            }
            else if (Move < 0)
            {
                offset.x -= ScrollSpeed * Time.deltaTime;
            }
            mt.SetTextureOffset("_MainTex", offset);
        }
    }
}
