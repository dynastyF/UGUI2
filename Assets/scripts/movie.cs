using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class movie : MonoBehaviour {
    //public Image image;
    public MovieTexture _movie;
    public AudioSource audioPlayer;
    private float time = 10f;
    private float jishi = 0;
    public string nextScene;

    void Awake() {
        //image.material.mainTexture = _movie;
        Play();
    }

    public void Play() {
        _movie.Play();
        audioPlayer.Play();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //jishi += Time.deltaTime;
        //if (jishi > time)
        //{
        //    SceneManager.LoadScene(nextScene);
        //}
        if (!_movie.isPlaying) {
            _movie.Stop();
            SceneManager.LoadScene(nextScene);
        }

	}
}
