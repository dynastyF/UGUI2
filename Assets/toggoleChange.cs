using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggoleChange : MonoBehaviour {
    public GameObject on;
    public GameObject off;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changOn(bool isOn) {
        on.SetActive(isOn);
        off.SetActive(!isOn);
    }
}
