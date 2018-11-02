using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour {

	private Vector3 goal;
	private Vector3 start;
	private NavMeshAgent agent;
	public GameObject camera;
	private int step;

	void Start () {
		Cursor.visible = false;

		start = transform.position;
		goal = transform.position;
		agent = GetComponent<NavMeshAgent> ();

		step = 0;
	}
	
	void Update () {
		//goal = transform.position
		//	+ camera.transform.right * Input.GetAxis("Horizontal")
		//	+ camera.transform.forward * Input.GetAxis("Vertical");

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown("space")) {
			goal.z -= 1.5f;
			if (step++ % 8 == 0) {
				goal = start;
				transform.position = start;
			}
        }

		agent.destination = goal;
		Debug.Log(agent.transform.position);
	}
}
