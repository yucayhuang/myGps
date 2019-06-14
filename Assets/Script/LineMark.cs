using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LineMark : MonoBehaviour {
 
	private LineRenderer line;  
	private int i;  
	Vector3 RunStart;
	Vector3 RunNext;
	
	void Start(){
		line = GetComponent<LineRenderer>();//获得该物体上的LineRender组件  
		//		//line.SetColors(Color.blue, Color.red);//设置颜色  
		//		//line.SetWidth(0.2f, 0.1f);//设置宽度  
		i = 0;
		RunStart = this.transform.position;	
	}
	
	// Use this for initialization
	void Awake () {		
		
	}
 
	// Update is called once per frame  
	void Update () {  
 
		RunNext = transform.position;
 
		if (RunStart != RunNext) {
			i++;
			line.positionCount  = i;//设置顶点数 
			line.SetPosition(i-1, RunNext);
		}
 
		RunStart = RunNext; 
	}  
}
