using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public static DoorScript Instance;
    private Animator anim;
    private BoxCollider2D box;
    private int Score = 0;
    public Text txtScore;

    [HideInInspector]
    public int CollectablesCount;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        box.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCollectables()
    {
        CollectablesCount--;
        Score++;

        txtScore.text = "Gem: " + Score.ToString();
        if (CollectablesCount == 0)
            StartCoroutine(DoorOpen());
    }
    IEnumerator DoorOpen()
    {
        //anim.Play("Open");
        yield return new WaitForSeconds(1f);
        box.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
