using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
	// Loads the scene specified by the string "changeScene" when a particular button is pressed
	public void SceneLoad(string changeScene){
		SceneManager.LoadScene(changeScene);
	}
	
	// Ends the game
	public void EndGame(){
		Application.Quit();
	}
}
