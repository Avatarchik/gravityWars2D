using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour
{
    public float turnSpeed = 50f;
    Vector3 lineDirectionNew;

    //Control the rotation by mouse
    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1.0f;
        Vector3 worldPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - worldPos.x;
        mousePos.y = mousePos.y - worldPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));  
    }

    public void RotateGameObject(Quaternion lineDirectionNew)
    {
        transform.rotation *= lineDirectionNew;
    }
}

