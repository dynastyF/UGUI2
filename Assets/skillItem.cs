using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillItem : MonoBehaviour {
    public float cd = 2f;
    private float timer = 0f;
    private bool isStart;
    private Image fillImage;
    public KeyCode keycode;
	// Use this for initialization
	void Start () {
        isStart = false;
        fillImage = transform.Find("fillskill").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(keycode))
        {
            isStart = true;
        }
        if (isStart)
        {
            timer += Time.deltaTime;
            fillImage.fillAmount = (cd - timer) / cd;
        }
        if(timer >= cd)
        {
            fillImage.fillAmount = 0;
           isStart = false;
            timer = 0f;
        }
	}

    public void onCLick()
    {
        isStart = true;
    }
}
