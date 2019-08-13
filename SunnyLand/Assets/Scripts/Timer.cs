using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float time = 100f;
    public float timeburn = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.value = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= timeburn*Time.deltaTime;
            slider.value = time;
        }
        else
        {
            time = 0;
            player.SetActive(false);
        }
    }
}
