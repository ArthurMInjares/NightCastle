using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		//Switches scene when Play Button is pressed
		SceneManager.LoadScene("Library_Level_V2");

	}

	    public void Menu()
    {
        //Switches scene when Menu button is pressed
        SceneManager.LoadScene("MainMenu");
	
    }

    public void Credits()
    {
        //Switches scene when Credit Button is pressed
        SceneManager.LoadScene("CreditScene");
		Time.timeScale = 1f;

    }

    public void QuitGame()
	{
		//Sends debug message saying "Quit Game"
		Debug.Log("Quit Game");

		//Closes application
		Application.Quit();

	}
}
