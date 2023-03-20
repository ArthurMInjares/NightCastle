using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    bool loadingStarted = false;
    float secondsLeft = 0;
void Start()
{
    StartCoroutine(DelayLoadLevel(68));
}
IEnumerator DelayLoadLevel(float seconds)
{
    secondsLeft = seconds;
    loadingStarted = true;
do
{
    yield return new WaitForSeconds(1);
} 
while (--secondsLeft > 0);
Application.LoadLevel("Assets/_Scenes/Version 2/Library_Level_V2.unity");
}
void OnGUI()
{
if (loadingStarted)
GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
}
}

