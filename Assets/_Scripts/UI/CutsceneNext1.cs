using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneNext1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutSceneTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CutSceneTimer()
    {
        yield return new WaitForSeconds(65);
        SceneManager.LoadScene(0);
    }
}
