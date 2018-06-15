using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class levelSroll : MonoBehaviour,IBeginDragHandler,IEndDragHandler {

    private ScrollRect scrollRect;
    private float[] PagePos = { 0.0f, 0.5f, 1.0f };
    private float targetPos;
    public float speed = 5f;
    public Toggle[] toggle;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float temp = scrollRect.horizontalNormalizedPosition;
        //Debug.Log("temp" +temp);
        int index = 0;
        float mintemp = Math.Abs(temp - PagePos[index]);
        //Debug.Log("mintemp" + mintemp);
        for (int i = 0; i < PagePos.Length; i++) {
            float posTemp = Math.Abs(temp - PagePos[i]);
            //Debug.Log("postemp" + i + posTemp);
            if (posTemp < mintemp)
            {
                index = i;
                Debug.Log(index);
                mintemp = posTemp;
            }
        }
        //Debug.Log(index);
        //scrollRect.horizontalNormalizedPosition = PagePos[index];
        targetPos = PagePos[index];
        toggle[index].isOn = true;
        //Debug.Log(temp);
    }

    // Use this for initialization
    void Start () {
        scrollRect = GetComponent<ScrollRect>();
    }
	
	// Update is called once per frame
	void Update () {
        scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetPos, Time.deltaTime*speed);
	}

    public void change0(bool isOn) {
        targetPos = PagePos[0];
    }
    public void change1(bool isOn)
    {
        targetPos = PagePos[1];
    }
    public void change2(bool isOn)
    {
        targetPos = PagePos[2];
    }
}
