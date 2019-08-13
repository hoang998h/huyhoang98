using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var WorldHeight = Camera.main.orthographicSize * 2f;
        var WorldWidth = WorldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(WorldWidth, WorldHeight, 0f);
    }
}
