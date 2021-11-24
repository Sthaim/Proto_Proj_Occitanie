using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public List<GameObject> Waypoint;
    public LineRenderer lineList;

    private void Update()
    {
        if (Waypoint.Count> 0) {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Waypoint[0].transform.position, 0.01f);
            if (gameObject.transform.position == Waypoint[0].transform.position)
            {
                removeWaypoint();
            }
        }
        
    }

    public void addWaypoint(GameObject gameObj)
    {
        Waypoint.Add(gameObj);
        lineList.positionCount = Waypoint.Count;
        for(int i = 0; i < lineList.positionCount; i++)
        {
            lineList.SetPosition(i,Waypoint[i].transform.position);

        }
    }
    public void removeWaypoint()
    {
        lineList.positionCount = Waypoint.Count;
        for (int i = 0; i < lineList.positionCount; i++)
        {
            lineList.SetPosition(i, Waypoint[i].transform.position);

        }
        Waypoint[0].SetActive(false);
        Destroy(Waypoint[0]);
        Waypoint.RemoveAt(0);

    }
}
