using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject spawnobj;

    private Cube selectedCube;

    private GameObject[] listTag;


    private void OnMouseDown()
    {
        listTag = GameObject.FindGameObjectsWithTag("Selected");
        if (listTag.Length > 0)
        {
            Debug.Log("oui");
            selectedCube = listTag[0].GetComponent<Cube>();
            InvokeRepeating("chiant", 0F, 0.1F);
        }
    }

    private void OnMouseUp()
    {
        CancelInvoke("chiant");
        StopCoroutine(launchMove());
    }

    private void chiant()
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


    private Ray GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePoint);
        return ray;
    }


    void Start()
    {
        listTag = GameObject.FindGameObjectsWithTag("Selected");
        if (listTag.Length > 0)
        {
            selectedCube = listTag[0].GetComponent<Cube>();
        }
        /*foreach (GameObject objet in )
        {

        }*/



    }

}