using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject SpawnObject;
    private string Tag;
    // Start is called before the first frame update
    void Start()
    {
        Tag = SpawnObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag(Tag).Length < 1)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Instantiate(SpawnObject,transform.position,Quaternion.identity);
    }
}
