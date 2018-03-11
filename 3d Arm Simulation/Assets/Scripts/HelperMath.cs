using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperMath {


	public static float GetAngleCosineRule (float len1, float len2, float angleReturnedLength) {
		return Mathf.Rad2Deg * Mathf.Acos ((Mathf.Pow (len1, 2) + Mathf.Pow (len2, 2) - Mathf.Pow (angleReturnedLength, 2)) / (2 * len1 * len2));
	}
	public static float SinRule (float dist1, float angle1, float dist2) {
		angle1 *= Mathf.Deg2Rad;
		Debug.Log ("Angle1: " + angle1 + ", dist1: " + dist1 + ", dist2: " + dist2);
		return Mathf.Rad2Deg * Mathf.Asin (Mathf.Sin(angle1)*dist2/dist1);
	}
	public static float SignedAngleBetween (this Vector2 v, Vector2 otherVec) {
		float ang = Vector2.Angle(v, otherVec);
		Vector3 cross = Vector3.Cross(v, otherVec);

		if (cross.z > 0)
			ang = 360 - ang;

		return ang;
	}	
}
