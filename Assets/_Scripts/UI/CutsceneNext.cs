using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneNext : MonoBehaviour
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
        yield return new WaitForSeconds(117);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
