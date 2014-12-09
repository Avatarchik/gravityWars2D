using UnityEngine;
using System.Collections;

public class CrateSpawner : MonoBehaviour
{

    public Transform box;
    public Vector3 pos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spwanBox();
        }

    }

    void spwanBox()
    {
        Transform t = GameObject.Instantiate(box) as Transform;
        t.position = pos;
        t.rigidbody.AddTorque(Random.value * 2 - 1, Random.value * 2 - 1, Random.value * 2 - 1);
    }
}
