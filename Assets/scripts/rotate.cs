/*Author: Ian Mankowski
 * Title: rotate
 * 
 * Usage:
 *place on playerShip
 *
 *About: This allows you to rotate the ship.
 */

using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour
{
    public float turnSpeed = 50f;


    //Control the rotation by arrow keys
    void Update ()
    { 
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);  
    }

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
}