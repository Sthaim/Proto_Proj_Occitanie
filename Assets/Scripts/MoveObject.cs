using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject spawnobj;

    private Cube selectedCube;

    private GameObject[] listTag;

    private List<GameObject> listCube;


    void Start()
    {
        listTag = GameObject.FindGameObjectsWithTag("Selected");
        if (listTag.Length > 0)
        {
            selectedCube = listTag[0].GetComponent<Cube>();
        }
    }

    private void OnMouseDown()
    {
        listTag = GameObject.FindGameObjectsWithTag("Selected");
        if (listTag.Length > 0)
        {
            selectedCube = listTag[0].GetComponent<Cube>();
            listCube = selectedCube.GetComponent<Cube>().Waypoint;
            for (int i =0; i < listCube.Count; i++)
            {
                Destroy(listCube[i]);
            }
            listCube.Clear();
            InvokeRepeating("Coroutine", 0F, 0.1F);
        }
    }

    private void OnMouseUp()
    {
        CancelInvoke("Coroutine");
        StopCoroutine(launchMove());
        FinTrait();
    }

    private void Coroutine()
    {
        StartCoroutine(launchMove());
    }

    IEnumerator launchMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetMouseWorldPos().origin, GetMouseWorldPos().direction, out hit))
        {
            if (hit.collider != null && hit.collider.tag == "Plane")
            {
                GameObject go = Instantiate(spawnobj, hit.point, Quaternion.identity);
                selectedCube.addWaypoint(go);
            }
        }
        yield return new WaitForSeconds(0.5f);
    }

    private void FinTrait()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetMouseWorldPos().origin, GetMouseWorldPos().direction, out hit))
        {
            if (hit.collider != null && hit.collider.tag == "Plane")
            {
                GameObject go = Instantiate(spawnobj, hit.point, Quaternion.identity);
                selectedCube.addWaypoint(go);
            }
        }
    }


    private Ray GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePoint);
        return ray;
    }


    

}