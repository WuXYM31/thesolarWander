using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rayCast_testing : MonoBehaviour
{


	//define infocanvas
	public Canvas infoCanvas;
	public Text name;
	public Text distance;
	public Text mass;
	public Text diameter;
	//define info data
	public string pName;
	public string pDistance;
	public string pMass;
	public string pDiameter;
	public string audiopath;
	//define audio data
	public AudioClip aClip;
	public AudioSource aSource;

	//load data
	public void LoadData (string currentPlanet)
	{
		switch (currentPlanet) {
		case "Sphere":
			pName = "Sun";
			pDistance = "5778Kelvin";
			pMass = "333000Earth";
			pDiameter = "1.39 million Km";
			audiopath = "";
			break;
		case "MercuryMain":
			pName = "Mercury";
			pDistance = "0.38AU";
			pMass = "0.55Earth";
			pDiameter = "4878Km";
			audiopath = "mercury";
			break;
		case "VenusMain":
			pName = "Venus";
			pDistance = "0.72AU";
			pMass = "0.815Earth";
			pDiameter = "12103.6km";
			audiopath = "venus";
			break;
		case "EarthMain":
			pName = "Earth";
			pDistance = "1AU";
			pMass = "5.965*10^24Kg";
			pDiameter = "12756.3km";
			audiopath = "";
			break;
		case "MarsMain":
			pName = "Mars";
			pDistance = "1.52AU";
			pMass = "0.107Earth";
			pDiameter = "6794km";
			audiopath = "mars";
			break;
		case "JupiterMain":
			pName = "Jupiter";
			pDistance = "5.20AU";
			pMass = "318Earth";
			pDiameter = "142984km";
			audiopath = "jupiter";
			break;
		case "SaturnMain":
			pName = "Saturn";
			pDistance = "9.54AU";
			pMass = "95Earth";
			pDiameter = "120536km";
			audiopath = "saturn";
			break;
		case "TitanMain":
			pName = "Titan";
			pDistance = "Moon of Saturn";
			pMass = "1.8Moon";
			pDiameter = "5151km";
			audiopath = "";
			break;
		case "UranusMain":
			pName = "Urnaus";
			pDistance = "19.218AU";
			pMass = "14Earth";
			pDiameter = "51120km";
			break;
		case "NeptuneMain":
			pName = "Neptune";
			pDistance = "30.96AU";
			pMass = "17Earth";
			pDiameter = "49528km";
			audiopath = "";
			break;
		default:
			pName = "";
			pDistance = "";
			pMass = "";
			pDiameter = "";
			audiopath = "";
			break;
		}
		name.text = pName;
		distance.text = pDistance;
		mass.text = pMass;
		diameter.text = pDiameter;
		aClip = Resources.Load<AudioClip> (audiopath);
	}

	//play audio
	public void PlayAudio(){
		if (!aSource.isPlaying) {
			aSource.PlayOneShot (aClip);
			Debug.Log ("audioguide is playing");
		}
	}

	//stop audio
	public void StopAudio(){
		if(aSource.isPlaying){
		aSource.Stop ();
		Debug.Log ("audioguide is stopped");
		}
	}

	//initialization
	void Start(){
		infoCanvas = GameObject.Find ("infoCanvas").GetComponent<Canvas> ();
		name = GameObject.Find ("name").GetComponent<Text> ();
		distance = GameObject.Find ("distance").GetComponent<Text> ();
		mass = GameObject.Find ("mass").GetComponent<Text> ();
		diameter = GameObject.Find ("diameter").GetComponent<Text> ();
		aSource = GameObject.Find ("audioguide").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update ()
	{

		RaycastHit hit;
		float theDistance;
		float range = 500f;
	
		//forward = object's forward direction with the speed of 8
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 20;

		//Draw a raycast line from camera's position to forward direction in green color
		Ray landingRay = new Ray (transform.position, forward);
		Debug.DrawRay (transform.position, forward, Color.green);

		//if raycast collides any object at a distance of 500, all animations are stopped
		if (Physics.Raycast (landingRay, out hit, range)) {
			theDistance = hit.distance;
			Debug.Log (theDistance + " " + hit.collider.gameObject.name);
			GameObject.Find ("CenterOfGravity_mercury").GetComponent<Mercury_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_venus").GetComponent<Venus_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_earth").GetComponent<Earth_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_mars").GetComponent<Mars_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_jupiter").GetComponent<Jupiter_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_saturn").GetComponent<Saturn_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_titan").GetComponent<Titan_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_uranus").GetComponent<Uranus_CenterOfGravity> ().enabled = false;
			GameObject.Find ("CenterOfGravity_neptune").GetComponent<Neptune_CenterOfGravity> ().enabled = false;
			//tell knowledge
			infoCanvas.enabled = true;
			LoadData(hit.collider.gameObject.name);
			PlayAudio();
		} else {
			GameObject.Find ("CenterOfGravity_mercury").GetComponent<Mercury_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_venus").GetComponent<Venus_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_earth").GetComponent<Earth_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_mars").GetComponent<Mars_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_jupiter").GetComponent<Jupiter_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_saturn").GetComponent<Saturn_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_titan").GetComponent<Titan_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_uranus").GetComponent<Uranus_CenterOfGravity> ().enabled = true;
			GameObject.Find ("CenterOfGravity_neptune").GetComponent<Neptune_CenterOfGravity> ().enabled = true;
			//not to tell knowledge
			infoCanvas.enabled = false;
			StopAudio ();
		}
	}
}
