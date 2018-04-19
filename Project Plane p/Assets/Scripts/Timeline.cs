using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour {
	public Slider slider;
	public Animation anim;

	bool playing;

	public Sprite pause;
	public Sprite play;
	public Image button;

	public void Start(){
		anim.Play("Main");
		anim["Main"].speed = 0;
	}
	public void Update(){
		if(anim["Main"].speed == 1){
			slider.value = anim["Main"].normalizedTime;
		}
		else{
			anim["Main"].normalizedTime = slider.value;
		}
		if(!anim.isPlaying){
			anim.Play("Main");
			button.sprite = play;
			anim["Main"].speed = 0;
			playing = false;
			CustomTimer.instance.ResetTimer();
		}
	}
	public void Play(){
		if(playing){
			anim["Main"].speed = 0;
			playing = false;
			button.sprite = play;
			CustomTimer.instance.ProgressTime();
		}
		else{
			anim["Main"].speed = 1;
			playing = true;
			button.sprite = pause;
			CustomTimer.instance.ProgressTime();			
		}
	}
	public void Pauze(){
		if(playing){
			anim["Main"].speed = 0;
			playing = false;
			button.sprite = play;
			CustomTimer.instance.ProgressTime();			
		}	
	}
}
