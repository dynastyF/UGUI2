using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMan : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("ArrivePos");
		 if (other.tag.Equals("ArrivePos"))
        {
           gameManager.changeRoad(other.transform);
		   Debug.Log("ArrivePos");
        }
	}
}
