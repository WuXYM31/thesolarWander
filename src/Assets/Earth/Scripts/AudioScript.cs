using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip MusicClip;
	public AudioSource MusicSource;
	public bool AudioPlay=true;

	// Use this for initialization
	void Start () {
		MusicSource.clip = MusicClip;
		MusicSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("joystick button 1")){
			if (AudioPlay == true){
				MusicSource.Stop ();
			}
			if (AudioPlay == false){
				MusicSource.Play();
			}
			AudioPlay = !AudioPlay;
		}
	}
}
