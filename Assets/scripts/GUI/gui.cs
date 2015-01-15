using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

    public int testNumber = 0;
    public int lastPower = 0;
    public int Player1TurnDisplay = 0;
    public int Player2TurnDisplay = 0;

    private gui guiScript;
    private GameObject sceneManager;

    public GameObject image;

    void Update () 
    {
        if (Input.GetKey("space"))
        {
            if (testNumber <= 100)
            {
                testNumber += 1;  
            }
            else 
            {
                testNumber = 100;
            }
            
        }
        if (Input.GetKeyUp("space"))
        {
            lastPower = testNumber;
            testNumber = 0;
        }
    }
}
