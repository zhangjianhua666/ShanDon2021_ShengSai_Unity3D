using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dazi : MonoBehaviour {

	private float time;//计时器
	public string textStr;//要显示的文字
	public Text txtGB;//文本组件
	private int idex=0;//字符串下标

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//计时器
		time += Time.deltaTime;
		//判断，如果idex小于字符串的长度则执行下面的代码
        if (idex<=textStr.Length)
        {
			if (time >= 0.2f)
			{
				txtGB.text = textStr.Substring(0, idex);
				idex++;
				time = 0;
			}
		}
       
	}
}
