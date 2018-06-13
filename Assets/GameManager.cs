using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//道路列表
	public List<Transform> roadList ;
	//道路切换点列表
	public List<Transform> arrivePosList;
	//障碍物的出生点
	public List<Transform> bornPosList;
	//障碍物种类列表
	public List<GameObject> objPrefabList;
	//目前障碍物列表
	Dictionary<string, List<GameObject>> objDict = new Dictionary<string, List<GameObject>>();
	public float roadHDistance;
	public float roadVDistence;

	// Use this for initialization
	void Start () {
		foreach(Transform road in roadList)
        {
            List<GameObject> objList  = new List<GameObject>();
            objDict.Add(road.name, objList);
        }
        initRoad(0);
        initRoad(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		//添加障碍
	void initRoad(int index){
		Debug.Log("aaaa");
		string roadName = roadList[index].name;
		// foreach (GameObject obj in objDict[roadName])
		// {
		// 	Destroy(obj);
		// }
		// objDict[roadName].Clear();
		Debug.Log("aaaa");
		foreach(Transform pos in bornPosList[index]){
			Debug.Log("hhh");
			GameObject prefab = objPrefabList[Random.Range(0, objPrefabList.Count)];
			GameObject obj = Instantiate(prefab, pos.position, pos.rotation) as GameObject;
			obj.tag = "Obstacle";
            objDict[roadName].Add(obj);
			Debug.Log("dddd");
		}
		Debug.Log("eee");
	}

	public void changeRoad(Transform arrivePos){
		int index = arrivePosList.IndexOf(arrivePos);
		if(index >= 0){
			int lastIndex = index - 1;
			if(lastIndex < 0){
				lastIndex = roadList.Count - 1;
			}
			roadList[index].position = roadList[lastIndex] .position +
				new Vector3(roadHDistance, roadVDistence, 0);
			
			initRoad(index);
		}
	}



	// void OnTriggerEnter(Collider other){
	// 	 Debug.Log("ArrivePos");
	// 	 if (other.name.Equals("ArrivePos"))
    //     {
    //        changeRoad(other.transform);
	// 	   Debug.Log("ArrivePos");
    //     }
	// }

	
}
