using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {

	public Transform target;

	Arm arm;

	void Start () {
		arm = GetComponent<Arm> ();
	}
	void Update () {
		Vector3 targetPosition = target.position;
		Vector3 inMotor1Space = arm.motorShaft1.transform.parent.InverseTransformPoint (targetPosition);
		inMotor1Space.y = arm.motorShaft1.position.y;

		Vector2 delta = new Vector2 (inMotor1Space.x, inMotor1Space.z);
		arm.motorShaft1.localEulerAngles = new Vector3 (0f, -delta.SignedAngleBetween (Vector2.right), 0f);


		Vector3 inMotor2Space = arm.motorShaft2.transform.parent.InverseTransformPoint (targetPosition);
		inMotor2Space.y = arm.motorShaft2.position.y;

		Vector2 motor2Delta = Vector2.ClampMagnitude (new Vector2 (inMotor2Space.x, inMotor2Space.z), arm.arm2Length + arm.arm3Length - 0.01f);

		float motor2AngleOffset = -motor2Delta.SignedAngleBetween (Vector2.up);

		float dist = motor2Delta.magnitude;

		float arm1Angle = HelperMath.GetAngleCosineRule (dist, arm.arm2Length, arm.arm3Length);
		float arm2Angle = HelperMath.GetAngleCosineRule (arm.arm3Length, arm.arm2Length, dist);

		arm.motorShaft2.localEulerAngles = new Vector3 (0f, motor2AngleOffset - arm1Angle, 0f);
		arm.motorShaft3.localEulerAngles = new Vector3 (0f, arm2Angle, 0f);
	}
}
