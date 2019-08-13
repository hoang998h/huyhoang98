using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch_Check : MonoBehaviour
{
    public bool Check;
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Stand();
    }
    public bool Stand()
    {
        return Check;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Check = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Check = true;

    }
}
