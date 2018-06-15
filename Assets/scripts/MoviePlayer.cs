using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoviePlayer : MonoBehaviour {
    public Image image;
    public MovieTexture movie;
    public AudioSource audioPlayer;
    // Use this for initialization

    void Awake()
    {
        image.material.mainTexture = movie;
        Play();
    }

    public void Play() {
        movie.Play();
        audioPlayer.Play();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!movie.isPlaying) {
            SceneManager.LoadScene("03next");
        }
	}
}
