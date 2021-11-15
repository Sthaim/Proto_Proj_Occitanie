using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public string draggingTag;
    public Camera cam;

    private Vector3 dis;
    private float posX;
    private float posZ;

    private bool touched = false;
    private bool dragging = false;

    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    void FixedUpdate()
    {

        if (Input.touchCount != 1)
        {
            dragging = false;
            touched = false;
            if (toDragRigidbody)
            {
                SetFreeProperties(toDragRigidbody);
            }
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == draggingTag)
            {
                toDrag = hit.transform;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();

                dis = cam.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - dis.x;
                posZ = Input.GetTouch(0).position.y - dis.z;

                SetDraggingProperties(toDragRigidbody);

                touched = true;
            }
            
        }

        if (touched && touch.phase == TouchPhase.Moved)
        {
            dragging = true;

            float posXNow = Input.GetTouch(0).position.x - posX;
            float posZNow = Input.GetTouch(0).position.y - posZ;
            Vector3 curPos = new Vector3(posXNow,dis.y , posZNow);

            Vector3 worldPos = cam.ScreenToWorldPoint(curPos) - previousPosition;
            worldPos = new Vector3(worldPos.x,0.0f , worldPos.z);

            toDragRigidbody.velocity = worldPos / (Time.deltaTime * 10);

            previousPosition = toDrag.position;
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
            touched = false;
            previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
            SetFreeProperties(toDragRigidbody);
        }

    }

    private void SetDraggingProperties(Rigidbody rb)
    {
        rb.useGravity = false;
        rb.drag = 20;
    }

    private void SetFreeProperties(Rigidbody rb)
    {
        rb.useGravity = true;
        rb.drag = 5;
    }
}