using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameControl : MonoBehaviour {
    public static GameControl gameCInstance;

    string filename = "D:/unityProjects/info" + "/Save" + "/GameData.sav";

    void Awake() {
        gameCInstance = this;
    }


    public void init() {
        readData();
    }

    public void exit() {
        saveData();
    }

    public void restart() {
        resetData();
    }

    void readData() {
        if (!IOHelper.IsFileExists(filename))
        {
            Debug.Log("文件不存在");
            gameInfo temp = new gameInfo();
            IOHelper.setData(filename, temp);
        }
        else {
            gameInfo temp = (gameInfo)IOHelper.GetData(filename, typeof(gameInfo));
            AudioManager._instance.setVolume(temp.volume);
        }
        //float t1 = (float)IOHelper.GetData(filename, typeof(float));
        //if(t1.Equals(""))
        //    Debug.Log("fasdfsad");
    }
    
    void saveData()
    {
        gameInfo temp = new gameInfo();
        temp.volume = AudioManager._instance.getVolume();
        Debug.Log(temp.volume);
        IOHelper.setData(filename, temp);
    }

    void resetData() {
        gameInfo temp = new gameInfo();
        IOHelper.setData(filename, temp);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public class gameInfo{
        public bool isNew = true; // 判断有没有存档
        public float volume = 0.5f;
        public float physical = 1.0f;
        public int haveOver = 0;
    }
}
