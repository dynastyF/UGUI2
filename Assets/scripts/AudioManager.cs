using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipType
{
    anjian,
    point,
    wing
}

public class AudioManager : MonoBehaviour {
    public static AudioManager _instance;

    public AudioClip[] allAudioClips;
    public AudioSource audioSourceOths;

    private float volume = 0.5f;
    // Use this for initialization
    void Awake()
    {
        _instance = this;
    }

    public void setAudio(AudioClipType index)
    {
        audioSourceOths.clip = allAudioClips[(int)index];
        audioSourceOths.Play();
    }

    public void setVolume(float value) {
        volume = value;
        Debug.Log("audio volume" + volume);
    }

    public float getVolume()
    {
        return volume;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
