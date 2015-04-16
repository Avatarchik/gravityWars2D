using UnityEngine;
using System.Collections;

public class planetCollision : MonoBehaviour {

	public int structuralIntegrity = 3;

	private void OnCollisionEnter2D(Collision2D collision)
	{
        structuralIntegrity -= 1;
    }


}


