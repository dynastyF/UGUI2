using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//http://www.unity.5helpyou.com/

public class EnemyUiHP : MonoBehaviour {
    public Text UI;
    int TapFlag = 1;
    string[] info = { "你好,我是NPC", "我什么都做不了", "你被欺骗了", "hhhh" };
    int nowInfo = 1;
    float time = 0.0f;
    bool keyOK = false;
    public float swichTime = 0.5f;
    // Use this for initialization
    void Start () {
        UI.transform.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.rotation =  Camera.main.transform.rotation;
        //      if (Input.GetKey(KeyCode.Q))
        //      {

        //          transform.gameObject.SetActive(!transform.gameObject.activeSelf);
        //          Debug.Log(transform.gameObject.activeSelf);
        //      }

        UI.transform.rotation = Camera.main.transform.rotation;
        //根据按键更改文字
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    if (nowInfo == 4)
        //        nowInfo = 0;
        //    UI.transform.gameObject.SetActive(!UI.transform.gameObject.activeSelf);
        //    UI.text = info[nowInfo];
        //    if (!UI.transform.gameObject.activeSelf)
        //    {
        //        nowInfo++;
        //    }
        //    Debug.Log(nowInfo);
        //    //UI.SetActive(!UI.transform.gameObject.activeSelf);
        //    //Debug.Log(UI.transform.gameObject.activeSelf);
        //}

        if (Input.GetKeyUp(KeyCode.R))
        {
            keyOK = true;
            UI.transform.gameObject.SetActive(true);
            Debug.Log("RR");
        }

        if(keyOK)
        {
            time += Time.deltaTime;
            if(time >= swichTime)
            {
                UI.text = info[nowInfo];
                nowInfo++;
                Debug.Log(UI.text);
                time = 0f;
            }
        }
        if(nowInfo == 4)
        {
            keyOK = false;
            UI.text = info[0];
            nowInfo = 0;
            UI.transform.gameObject.SetActive(false);
        }
    }
}
