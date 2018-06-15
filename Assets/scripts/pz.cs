using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pz : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	  void OnTriggerEnter(Collider collider) {
          Debug.Log("开始接触");
      }
}
