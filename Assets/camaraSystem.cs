using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSystem : MonoBehaviour
{
	private void Update()
	{
		Vector3 inputDir = new Vector3(0, 0, 0);

		if (Input.GetKey(KeyCode.W)) { inputDir.z = +1f; }
		if (Input.GetKey(KeyCode.S)) inputDir.z = -1f;
		if (Input.GetKey(KeyCode.A)) inputDir.x = -1f;
		if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;

		int edgeScrollSize = 20;

		if (Input.mousePosition.x < edgeScrollSize)
		{
			inputDir.x = -1f;
		}
		if (Input.mousePosition.y < edgeScrollSize)
		{
			inputDir.z = -1f;
		}
		if (Input.mousePosition.x > Screen.width - edgeScrollSize)
		{
			inputDir.x = +1f;
		}
		if (Input.mousePosition.x > Screen.height - edgeScrollSize)
		{
			inputDir.z = +1f;
		}


		Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

		float moveSpeed = 50f;
		transform.position += moveDir * moveSpeed * Time.deltaTime;


		float rotateDir = 0f;
		if (Input.GetKey(KeyCode.Q)) rotateDir = +1f;
		if (Input.GetKey(KeyCode.E)) rotateDir = -1f;

		//float rotateDir = 100f;
		//transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);

	}
}
