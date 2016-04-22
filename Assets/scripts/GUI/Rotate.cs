using UnityEngine;
using System.Collections;
 
public class Rotate : MonoBehaviour
{
    private const float startAngle = 45;
    void Update ()
    {
        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D c = Physics2D.OverlapPoint(mp);
 
        if (c != null && c.gameObject.tag == "Handle" && Input.GetButton("Fire1"))
        {
            Vector2 dir = mp - (Vector2)transform.position;
 
            float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg - startAngle;
 
            if (angle < transform.eulerAngles.z)
            {
                transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}