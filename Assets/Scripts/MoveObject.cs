using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject spawnobj;

    public Cube selectedCube;


    private void OnMouseDown()
    {
        InvokeRepeating("chiant", 0F, 0.1F);
        
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
        


    }

}