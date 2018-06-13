using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMovieByMaterial : MonoBehaviour {
    public MovieTexture _movie;
	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = _movie;
        _movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
