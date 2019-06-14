using UnityEngine;
using System.Collections;
using System;
 
public class Run : MonoBehaviour
{
	public float speed = 10f;    //速度
	public static double kmPerH = 0d;
	public static float totalKM = 0f;
	public static float latitude = 0f;
	public static float longitude = 0f;
	double timeStamp;
	public static string stateInfo = "";
	Vector3 targetPos;
	Vector3 centerPos;
 
	void Start(){
		StartCoroutine(StartGPS());
	}
	
	IEnumerator StartGPS () { 
        // Input.location 用于访问设备的位置属性（手持设备）, 静态的LocationService位置  
        // LocationService.isEnabledByUser 用户设置里的定位服务是否启用  
        if (!Input.location.isEnabledByUser) {  
           stateInfo = "没有打开定位";
           //yield return false;  
        }  
		stateInfo = Input.location.status.ToString();
        // LocationService.Start() 启动位置服务的更新,最后一个位置坐标会被使用  
		if (Input.location.status != LocationServiceStatus.Running)
			Input.location.Start(1.0f, 1.0f);  
        int maxWait = 20;  
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {  
            // 暂停协同程序的执行(1秒)  
            yield return new WaitForSeconds(1);  
            stateInfo = "定位中...("+maxWait+")";
            maxWait--;  
        }  
  
        if (maxWait < 1) {
			stateInfo = "定位超时";
			yield return new WaitForSeconds(2);  
        }  
  
        if (Input.location.status == LocationServiceStatus.Failed) {
            stateInfo = "无法使用定位";
            yield return new WaitForSeconds(2);  
        }   
	//	if (Input.location.status != LocationServiceStatus.Running) {
    //        stateInfo = Input.location.status.ToString();
    //        yield break;  
    //  }   
		stateInfo = "";
        while (true){
			float newLongitude = getLongitude();
			float newLatitude = getLatitude();
			kmPerH = 0;
			if(newLatitude != latitude && newLongitude != longitude){
				if(latitude == 0 && longitude == 0){
					centerPos = GpsUtil.MillierConvertion(newLongitude, newLatitude);
					timeStamp = getTimestamp();
				}else{
					float dis = GpsUtil.GetDistance(longitude, latitude, newLongitude, newLatitude);//计算总公里数
					if(dis > 0){
						double time = getTimestamp();
						kmPerH = dis / ((time - timeStamp)/3.6);
						timeStamp = time;
						totalKM += dis;
					}
				}
				targetPos = GpsUtil.MillierConvertion(newLongitude, newLatitude) - centerPos;
				
				//让始终它朝着目标
				this.transform.LookAt(targetPos);
				//float currentDist = Vector3.Distance(this.transform.position, targetPos);
				this.transform.position = targetPos;//(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
				
				latitude = newLatitude;
				longitude = newLongitude;
			}
			yield return new WaitForSeconds(1);
		}
    }  
		
	float getLongitude(){
		return Input.location.lastData.longitude; 
	}
	
	float getLatitude(){
		return Input.location.lastData.latitude;
	}
	
	
	double getTimestamp(){
		return Input.location.lastData.timestamp;
	}
	
}