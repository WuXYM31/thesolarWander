#pragma strict

var timer:float = 1.0f;

function Start () {
	
}

function Update () {
timer -= Time.deltaTime;
if (timer<=0){
Application.LoadLevel("EarthScene");
}
	
}
