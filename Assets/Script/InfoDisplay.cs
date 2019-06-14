using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnGUI(){
		if (Run.stateInfo == ""){//.location.isEnabledByUser) {
			GUIStyle fontStyle = new GUIStyle(); //实例化一个新的GUIStyle，名称为style ，后期使用
			fontStyle.fontSize = 100; //字体的大小设置数值越大，字越大，默认颜色为黑色 
			fontStyle.normal.textColor=new Color(0,2,4); //设置文本的颜色为 新的颜色(0,0,0)修改值-代表不同的颜色
			GUI.Box(new Rect(0, 0, 900, 450), "");
			GUI.Label(new Rect(50, 50, 400, 100), "经度", fontStyle);
			GUI.Label(new Rect(400, 50, 400, 100), Run.longitude.ToString("F3"), fontStyle);
			GUI.Label(new Rect(50, 150, 400, 100), "纬度", fontStyle);
			GUI.Label(new Rect(400, 150, 400, 100), Run.latitude.ToString("F3"), fontStyle);
			GUI.Label(new Rect(50, 250, 400, 100), "里程", fontStyle);
			GUI.Label(new Rect(400, 250, 400, 100), Run.longitude, fontStyle);//(totalKM/1000).ToString("F1")+"km", fontStyle);
			GUI.Label(new Rect(50, 350, 400, 100), "时速", fontStyle);
			GUI.Label(new Rect(400, 350, 400, 100), "16km/h", fontStyle);// (kmPerH).ToString("F0")+"km/h", fontStyle);
			GUIStyle fontStyle2 = new GUIStyle(); //实例化一个新的GUIStyle，名称为style ，后期使用
			fontStyle2.fontSize = 100; //字体的大小设置数值越大，字越大，默认颜色为黑色 
			fontStyle2.normal.textColor = Color.red; //设置文本的颜色为 新的颜色(0,0,0)修改值-代表不同的颜色
			if(GUI.Button(new Rect(50, 450, 400, 100), "呼救", fontStyle2)){
				Debug.Log("正在呼叫救援人员...");
			}
		}else{
			GUIStyle fontStyle3 = new GUIStyle(); //实例化一个新的GUIStyle，名称为style ，后期使用
			fontStyle3.fontSize = 100; //字体的大小设置数值越大，字越大，默认颜色为黑色 
			fontStyle3.normal.textColor = Color.gray; //设置文本的颜色为 新的颜色(0,0,0)修改值-代表不同的颜色
			GUI.Box(new Rect(10, 10, 600, 50), "");
			GUI.Label(new Rect(10, 10, 600, 50), Run.stateInfo, fontStyle3);
		}
	}
	
}
