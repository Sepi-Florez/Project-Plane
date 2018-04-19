using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTimer : MonoBehaviour {
	public static CustomTimer instance;

	public Animation anim;

	public int minuteLeap;
	public Vector2 startingTime;
	public Text timer;

	public Vector2 currentTime;

	private void Awake() {
		instance = this;
		timer.text = IntToTimeString(startingTime);
		currentTime = startingTime;
	}
	private string IntToTimeString(Vector2 time){
		Debug.Log(time);
		string newTimeString = "";

		if(time.x < 10){
			newTimeString += "0";
		}
		newTimeString += time.x + ":";
		if(time.y < 10){
			newTimeString += "0";
		}
		newTimeString += time.y;

		return newTimeString;

	}
	public void Update(){
		if(anim["Main"].speed == 1){
			ProgressTime();
		}
	}
	public void ProgressTime(){
		Debug.Log("Progressing Time");
		float time = anim["Main"].time;
		Debug.Log("Base Time Value: " + time);
		Debug.Log("Rounded Time Value: " + (int)time);
		Debug.Log("Weird Number: " + (int)((((int)time * 10) / 60) * 60));
		currentTime.y = (int)time * 10 -(int)((((int)time * 10) / 60) * 60);
		currentTime.x = (int)anim["Main"].time / 6 + startingTime.x; 
		Debug.Log("Pre check: " + currentTime);
		Debug.Log("After check: " + currentTime);

		timer.text = IntToTimeString(currentTime);
	}
	public void ResetTimer(){
		timer.text = IntToTimeString(startingTime);
		currentTime = startingTime;
	}
}
