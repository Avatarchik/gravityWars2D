using UnityEngine;
using System.Collections;
using System.Reflection;

public class enableScript : MonoBehaviour

{
    torpedo myScript;               //gets the torpedo function
    rotate rotateScript;            //gets the rotate functionality

    public int playerIdentifier;
    
    
    void Start ()
    {
        myScript = GetComponentInChildren<torpedo>();
        rotateScript = GetComponentInChildren<rotate>();
    }
    
    
    public void playerSwitch(bool state)
    {
        if (state)
        {
            myScript.enabled = true;
            rotateScript.enabled = true;

        }
        else
        {
            myScript.enabled = false;
            rotateScript.enabled = false;
        }
        myScript.cdFlag = true;
    }
}