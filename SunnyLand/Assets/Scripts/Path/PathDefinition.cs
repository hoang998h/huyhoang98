using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    public Transform[] listPoints;
    public int StartAt=0;
    public int direction = 1;
    // Start is called before the first frame update
    private void Start()
    {
    }
    private void OnDrawGizmos()
    {
        if(listPoints == null || listPoints.Length < 2)
        {
            return;
        }
        for(int i=1;i<listPoints.Length;i++)
        {
            Gizmos.DrawLine(listPoints[i - 1].position, listPoints[i].position);
        }
    }
    public Transform getPointAt(int p)
    {
        return listPoints[p];
    }
    // Update is called once per frame
    public Transform getNextPoint()
    {

        if(StartAt == 0)
        {
            direction = 1;
        }
        else if (StartAt== listPoints.Length-1)
        {
            direction = -1;
        }
        StartAt += direction;
        
        return listPoints[StartAt];
    }
}
