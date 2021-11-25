using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public List<GameObject> Waypoint;
    public LineRenderer prefabLineRend;
    private GameObject[] listTag;

    private void Start()
    {
        prefabLineRend=Instantiate(prefabLineRend, new Vector3(0, 0, 0), Quaternion.identity);
    }
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

    private void OnMouseDown()
    {
        
        listTag = GameObject.FindGameObjectsWithTag("Selected");
        foreach (GameObject cube in listTag)
        {
            cube.tag = "Untagged";
            cube.GetComponent<Renderer>().material.color = Color.white;
            cube.GetComponent<Cube>().prefabLineRend.SetColors ( Color.white, Color.white);
        }

        gameObject.tag = "Selected";
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        gameObject.GetComponent<Cube>().prefabLineRend.SetColors(Color.blue, Color.blue);
    }

    public void addWaypoint(GameObject gameObj)
    {
        Waypoint.Add(gameObj);
        prefabLineRend.positionCount = Waypoint.Count;
        for(int i = 0; i < prefabLineRend.positionCount; i++)
        {
            prefabLineRend.SetPosition(i,Waypoint[i].transform.position);

        }
    }
    public void removeWaypoint()
    {
        Debug.Log(gameObject.name);
        prefabLineRend.positionCount = Waypoint.Count;
        for (int i = 0; i < prefabLineRend.positionCount; i++)
        {
            prefabLineRend.SetPosition(i, Waypoint[i].transform.position);

        }
        Waypoint[0].SetActive(false);
        Destroy(Waypoint[0]);
        Waypoint.RemoveAt(0);

    }
}
