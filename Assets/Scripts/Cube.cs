using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public List<GameObject> Waypoint;
    public LineRenderer prefabLineRend;
    private GameObject[] listTag;
    public float Offset;
    private Vector3 offsetPos;

    private void Start()
    {
        prefabLineRend=Instantiate(prefabLineRend, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void Update()
    {
        if (Waypoint.Count > 0) {
            offsetPos = new Vector3(Waypoint[0].transform.position.x, Waypoint[0].transform.position.y + Offset, Waypoint[0].transform.position.z);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, offsetPos, 0.01f);
            if (gameObject.transform.position == offsetPos)
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
        gameObject.GetComponent<Cube>().prefabLineRend.SetColors(Color.black, Color.green);
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
        Vector3[] newPositions = new Vector3[prefabLineRend.positionCount - 1];
        for (int i = 0; i < newPositions.Length; i++)
        {
            newPositions[i] = prefabLineRend.GetPosition(i + 1);
        }
        prefabLineRend.SetPositions(newPositions);

        Waypoint[0].SetActive(false);
        Destroy(Waypoint[0]);
        Waypoint.RemoveAt(0);
        Debug.Log(Waypoint.Count);
    }
}
