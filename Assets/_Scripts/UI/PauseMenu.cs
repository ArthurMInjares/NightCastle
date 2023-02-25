using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;

     private void Update()
    {

    //Activates and deactivates pause menu when pressing Escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           isPaused = !isPaused;
		}

        if (isPaused)
        {
            ActivateMenu();  
		}

        else
        {
            DeactivateMenu();  
		}
    }
    
    //Pauses game by setting timescale to 0
    void ActivateMenu()
    {

   Time.timeScale = 0f;
    pauseMenuUI.SetActive(true);
	}

    //Resumes game by setting timescale to 1
    public void DeactivateMenu()
    {
   Time.timeScale = 1f;
    pauseMenuUI.SetActive(false);
    isPaused = false;
	}

    //Switches Scene to Main Menu
    public void Menu()
    {
        Time.timeScale = 1f;
        //Switches scene when Menu button is pressed
        SceneManager.LoadScene("MainMenu");
		
    }

    public void Restart()
    {
        
        //Resets scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
