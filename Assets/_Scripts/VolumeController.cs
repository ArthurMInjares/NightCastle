using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Look up "dont destroy on load"
//Add player preferences
// Singleton Pattern


public class VolumeController : MonoBehaviour
{

private static readonly string BackgroundPref = "BackgroundPref";
private static readonly string FirstPlay = "FirstPlay";
private int FirstPlayInt;
public Slider backgroundSlider;
private float backgroundfloat;
public AudioSource backgroundAudio;

void Start()
{
	FirstPlayInt = PlayerPrefs.GetInt(FirstPlay);

	//sets slider to default value
	if (FirstPlayInt == 0)
	{
		backgroundfloat = .125f;
		backgroundSlider.value = backgroundfloat;
		PlayerPrefs.SetFloat(BackgroundPref, backgroundfloat);
		PlayerPrefs.SetInt(FirstPlay, -1);
	}
	else
	{
		backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
		backgroundSlider.value = backgroundfloat;
	}
}

public void PlayerSoundSettings()
{

PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);

}

void OnApplicationFocus(bool inFocus)
{
	if(!inFocus)
	{
		PlayerSoundSettings();
	}
}

public void UpdateSound()
{
	backgroundAudio.volume = backgroundSlider.value;
}

}
