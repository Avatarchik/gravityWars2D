using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

    public int testNumber = 0;
    public int lastPower = 0;
    public int Player1TurnDisplay = 0;
    public int Player2TurnDisplay = 0;

    void Update () 
    {
        if (Input.GetMouseButton(0) || Input.GetKey("space"))
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
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp("space"))
        {
            lastPower = testNumber;
            testNumber = 0;
        }
    }
}