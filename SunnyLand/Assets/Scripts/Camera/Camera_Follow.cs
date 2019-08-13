using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player!=null)
        {
            Vector3 camera_position = transform.position;
            camera_position.x = player.position.x;
            camera_position.y = player.position.y;
            transform.position = camera_position;
        }
    }
}
