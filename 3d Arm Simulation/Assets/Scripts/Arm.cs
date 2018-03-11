using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Arm : MonoBehaviour {


	public Transform motorShaft1, motorShaft2, motorShaft3;
	public Transform arm2, arm3;
	public Renderer arm2Visual, arm3Visual;

	public float arm2Length = 5f, arm3Length = 5f;
	public float armWidth = 1f;
	public float motorEdgeOffset = 0.5f;
	public float armThickness = 0.1f;

	void Update () {
		float actualArm2Length =  arm2Length + motorEdgeOffset * 4f;
		arm2Visual.transform.localScale = new Vector3 (armWidth, actualArm2Length, armThickness);//Motor edge offset is half of the motors size, first arm contains 2 motors
		arm2Visual.transform.localPosition = new Vector3 (0f, 0f, actualArm2Length/2f - motorEdgeOffset);

		motorShaft3.transform.parent.localPosition = new Vector3 (0f, -0.6f, actualArm2Length - motorEdgeOffset*2f);


		float actualArm3Length = arm3Length + motorEdgeOffset * 2f;
		arm3Visual.transform.localScale = new Vector3 (armWidth, actualArm3Length, armThickness);
		arm3Visual.transform.localPosition = new Vector3 (0f, 0f, actualArm3Length / 2f - motorEdgeOffset);
	}
}
