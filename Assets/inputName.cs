using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputName : MonoBehaviour {
    private string name;
    private bool isInput = false;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<InputField>().onValueChanged.AddListener(delegate
        //{
        //    isInput = true;
        //});

        //if (isInput) {
        //    GetComponent<InputField>().onEndEdit.AddListener(delegate
        //    {
        //        name = GetComponent<InputField>().text;
        //        Debug.Log(name);
        //        isInput = false;
        //    });
        //}
       

    }

    public void isENd(string n) {
        name = n;
        PlayerPrefs.SetString("name", name);
        GlobalControl.Instance.nname = name;
        Debug.Log(name);
    }

    public void nextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
