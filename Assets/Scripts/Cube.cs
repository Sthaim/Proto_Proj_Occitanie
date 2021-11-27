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
    private int nbrIte;
    private int dernierCount;
    private bool beenMoving;
    private bool firstMov;
    private bool moving;
    public Vector3 dernierePos;

    private void Start()
    {
        prefabLineRend=Instantiate(prefabLineRend, new Vector3(0, 0, 0), Quaternion.identity);
        firstMov = true;
        beenMoving = false;
    }

    private void Update()
    {
        if (Waypoint.Count > 0 && dernierCount>0) {
            offsetPos = new Vector3(Waypoint[0].transform.position.x, Waypoint[0].transform.position.y + Offset, Waypoint[0].transform.position.z);
            dernierePos = gameObject.transform.position;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, offsetPos, 0.01f);
            if (gameObject.transform.position== dernierePos)
            {
                moving = false;
            }
            
            if (gameObject.transform.position == offsetPos)
            {
                removeWaypoint(0);
            }
        }
        if (nbrIte == 1 && Waypoint.Count > 2 && beenMoving==true && firstMov==false && moving == true)
        {
            Debug.Log("SupprDerniereLigne");
            int count = Waypoint.Count;
            for (int i = 0; i < count; i++)
            {
                removeWaypoint(0);
            }
            UpdateBoolBeenMoving(false);
            
        }
        if (nbrIte > 1)
        {
            moving = true;
        }

    }

    public void UpdateIteration( int ite)
    {
        nbrIte = ite;
    }

    public void UpdateBoolBeenMoving(bool move)
    {
        beenMoving = move;
    }

    public void UpdateBoolFirst(bool first)
    {
        firstMov = first;
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
        dernierCount = Waypoint.Count;
        Waypoint.Add(gameObj);
        prefabLineRend.positionCount = Waypoint.Count;
        for(int i = 0; i < prefabLineRend.positionCount; i++)
        {
            prefabLineRend.SetPosition(i,Waypoint[i].transform.position);
        }
    }

    public void removeWaypoint(int index)
    {
       
        dernierCount = Waypoint.Count;
        Vector3[] newPositions = new Vector3[prefabLineRend.positionCount - 1];

        for (int i = 0; i < index; i++)
        {
            newPositions[i] = prefabLineRend.GetPosition(i);


        }
        for (int i = index; i < newPositions.Length; i++)
        {
            newPositions[i] = prefabLineRend.GetPosition(i + 1);

           
        }
        prefabLineRend.positionCount=newPositions.Length;
        prefabLineRend.SetPositions(newPositions);

        Waypoint[index].SetActive(false);
        Destroy(Waypoint[index]);
        Waypoint.RemoveAt(index);
    }
}
