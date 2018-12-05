using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findClosestPlanent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//getting all the planets and centerofgravity to stop animation
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("Planets");

		GameObject closest = null;

		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			/*float dist = Vector3.Distance (go.transform.position, position);
			if (dist >= 50 && dist <= 100) {*/

			Vector3 directionToTarget = position - go.transform.position;
			float angle = Vector3.Angle(transform.forward, directionToTarget);
			float distance = directionToTarget.magnitude;

			Debug.Log ("go" + go + "angle" + angle);
			Debug.Log ("distance" + distance);

			if (Mathf.Abs (angle) > 90 && distance < 150) {
				Debug.Log ("target is in front of me");
				Debug.Log ("1");
				closest = go;
				Debug.Log ("Closest Planet" + closest);
				Debug.Log ("angle" + angle);
				Debug.Log ("dist" + distance);
				GameObject.Find ("CenterOfGravity_mercury").GetComponent<Mercury_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_venus").GetComponent<Venus_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_earth").GetComponent<Earth_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_mars").GetComponent<Mars_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_jupiter").GetComponent<Jupiter_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_saturn").GetComponent<Saturn_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_titan").GetComponent<Titan_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_uranus").GetComponent<Uranus_CenterOfGravity> ().enabled = false;
				GameObject.Find ("CenterOfGravity_neptune").GetComponent<Neptune_CenterOfGravity> ().enabled = false;
			}
			else{
			    GameObject.Find ("CenterOfGravity_mercury").GetComponent<Mercury_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_venus").GetComponent<Venus_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_earth").GetComponent<Earth_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_mars").GetComponent<Mars_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_jupiter").GetComponent<Jupiter_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_saturn").GetComponent<Saturn_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_titan").GetComponent<Titan_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_uranus").GetComponent<Uranus_CenterOfGravity> ().enabled = true;
				GameObject.Find ("CenterOfGravity_neptune").GetComponent<Neptune_CenterOfGravity> ().enabled = true;			
			}
		}
	}

}
