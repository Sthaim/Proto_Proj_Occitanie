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
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Waypoint[0].transform.position, 0.05f);
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
        if (Waypoint.Count == 0) return;
        for(int i = 0; i < lineList.positionCount; i--)
        {
            Debug.Log(Waypoint[i].transform.position);
            lineList.SetPosition(i,Waypoint[i].transform.position);

        }
    }
    public void removeWaypoint()
    {
        Waypoint[0].SetActive(false);
        Destroy(Waypoint[0]);
        Waypoint.RemoveAt(0);

    }
}
