using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void changeSpeed(float spe)
    {
        speed = spe;
    }
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
