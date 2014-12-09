using UnityEngine;
using System.Collections;

public static class mathTools {

	//remaps a range to another range
	public static float Remap(float value, float from1, float to1, float from2, float to2)
	{
		return from2 + (value - from1) * (to2 - from2) / (to1 - from1);
	}
}
