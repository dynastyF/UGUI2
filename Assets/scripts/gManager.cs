using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gManager : MonoBehaviour {

	// Use this for initialization
	public void startGame(string sceneName){
        //Application.LoadLevel(sceneName);
        SceneManager.LoadScene(sceneName);
	}
}
