using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setName : MonoBehaviour {
    private string gName;
	// Use this for initialization
	void Start () {
        //gName = PlayerPrefs.GetString("name");
        gName = GlobalControl.Instance.nname;
    }
	
	// Update is called once per frame
	void Update () {
        transform.gameObject.GetComponent<Text>().text = gName;
	}
}
