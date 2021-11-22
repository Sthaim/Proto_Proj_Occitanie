using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public Camera cam;
    private Vector3 mOffset;
    private float mZCoord = 0;


    private void OnMouseDown()
    {
        /*mOffset = gameObject.transform.position - GetMouseWorldPos();*/
        /*mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;*/
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseDrag()
    {
        /*transform.position = GetMouseWorldPos() + mOffset;*/
        gameObject.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    void Start()
    {
       
        

    }

}