using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videoplayer : MonoBehaviour
{
    // Start is called before the first frame update
    string filePath;
    void Start()
    {
        filePath = Application.dataPath;
        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.playOnAwake = true;

        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        videoPlayer.targetCameraAlpha = 0.5F;

        videoPlayer.url = filePath + "/_Cutscenes/NightCastle_Storyboard.mp4";

        videoPlayer.frame = 100;

        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
