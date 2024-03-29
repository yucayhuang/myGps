﻿using UnityEngine;
using System.Collections;
using System;
 
 
public class GpsUtil{
 
	private static double EARTH_RADIUS = 6378137d;// 赤道半径(单位m)
 
	/**
	 * 转化为弧度(rad)
	 */
	private static double rad(double d) {
		return d * Math.PI / 180.0;
	}
 
	/**
	 * 基于googleMap中的算法得到两经纬度之间的距离,计算精度与谷歌地图的距离精度差不多，相差范围在0.2米以下（单位m）
	 * 
	 * @param lon1 第一点的精度
	 * @param lat1 第一点的纬度
	 * @param lon2 第二点的精度
	 * @param lat3 第二点的纬度
	 * @return 返回的距离，单位km
	 */
	public static float GetDistance(double lon1, double lat1, double lon2, double lat2) {
		double radLat1 = rad(lat1);
		double radLat2 = rad(lat2);
		double a = radLat1 - radLat2;
		double b = rad(lon1) - rad(lon2);
		double s = 2 * Math.Asin(Math.Sqrt(
				Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
		s = s * EARTH_RADIUS;
		// s = Math.Round(s * 10000) / 10000;
		return (float)s;
 
	}
	
	
	/**(米勒投影算法）将经纬度转化为平面坐标 （单位m）
	 * @param lon 经度
	 * @param lat 维度
	 * @return   
	 * @author shaosen
	 * @Date 2018年8月24日
	 */
	public static Vector3 MillierConvertion(double lon, double lat)  
    {  
         double L = 6381372  * Math.PI * 2;//地球周长  
         double W=L;// 平面展开后，x轴等于周长  
         double H=L/2;// y轴约等于周长一半  
         double mill=2.3;// 米勒投影中的一个常数，范围大约在正负2.3之间  
         double x = lon * Math.PI / 180;// 将经度从度数转换为弧度  
         double y = lat * Math.PI / 180;// 将纬度从度数转换为弧度  
         y=1.25 * Math.Log( Math.Tan( 0.25 * Math.PI + 0.4 * y ) );// 米勒投影的转换  
         // 弧度转为实际距离  
         x = ( W / 2 ) + ( W / (2 * Math.PI) ) * x;  
         y = ( H / 2 ) - ( H / ( 2 * mill ) ) * y;  
//         double[] result=new double[2];  
//         result[0]=x;  
//         result[1]=y; 
Debug.Log(x +"xxxxxxxxxxxxxx"+ y);
         return new Vector3((float)x, 1f, (float)y);  
    }
 
}