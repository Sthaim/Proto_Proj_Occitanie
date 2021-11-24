using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public List<GameObject> Waypoint;

    private void Update()
    {
        Debug.Log(Waypoint.Count);
        if (Waypoint.Count> 0) {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Waypoint[0].transform.position, 100);
        }   
        /*if (Waypoint[0]!= null && gameObject.transform.position == Waypoint[0].transform.position)
        {
            removeWaypoint();
        }*/
    }

    public void addWaypoint(GameObject gameObj)
    {
        Waypoint.Add(gameObj);
    }
    public void removeWaypoint()
    {
        Waypoint.RemoveAt(0);
    }
}
