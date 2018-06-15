using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControll : MonoBehaviour {
    public bool isContinue;
    public GameObject continueBtn;
    public GameObject secBackground;
    public GameObject confirmSettingBg;
    public GameObject exitBg;
    public Slider slider;       //控制音量，测试使用
    private float volumeOfSlider;
    private float lastVolume;
    player1 pp = new player1();
	// Use this for initialization
	void Start () {
        isContinue = false;
        lastVolume = 0.5f;

        GameControl.gameCInstance.init();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            isContinue = !isContinue;
        continueBtn.SetActive(isContinue);

        volumeOfSlider = slider.value;
       // Debug.Log("aaa");
        //Debug.Log(pp.engine);
    }

    //开始游戏
    public void StartGame(string nextScene) {
        GameControl.gameCInstance.restart();
        SceneManager.LoadScene(nextScene);
    }

    public void ContineGame(string nextScene) {
        SceneManager.LoadScene(nextScene);
    }

    public void Setting() {
        AudioManager._instance.setAudio(AudioClipType.anjian);
        ReadSettingData();
        secBackground.SetActive(true);
    }

    private void ReadSettingData()
    {
        slider.value = AudioManager._instance.getVolume();
    }

    public void exitSetting() {
        secBackground.SetActive(false);
    }

    public void ConfirmSetting() {
        confirmSettingBg.SetActive(true);
    }

    public void ExitConfrimSetting() {
        confirmSettingBg.SetActive(false);
    }

    public void SaveSetting() {
        //保存设置
        //并推出开始界面
        //Debug.Log(volumeOfSlider);
        AudioManager._instance.setVolume(volumeOfSlider);
        ExitConfrimSetting();
        exitSetting();
    }

    //退出游戏
    //进入是否确认退出界面
    public void Exit() {
        exitBg.SetActive(true);
        //Application.Quit();
    }

    public void confirmExit() {
        GameControl.gameCInstance.exit();
        Application.Quit();
    }

    public void NotExit() {
        exitBg.SetActive(false);
    }
}
