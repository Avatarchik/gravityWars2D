using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

    public int testNumber = 0;
    public int lastPower = 0;

    public int targetingAngle = 0;
    public int oldTargetingAngle;

    public bool updateFlag = false;

    
    void Update () {
        checkChange(testNumber, lastPower);
        checkChange(targetingAngle, oldTargetingAngle);
    }

    void checkChange(int variableOne, int variableTwo){
        if (variableOne != variableTwo)
        {
            variableOne = variableTwo;
            updateFlag = true;  
        }
        else
        {
            updateFlag = false;
        }
        
    }
    

}
