using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuZiDan : MonoBehaviour {
	public GameObject ZiDanGB;//子弹预制体
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
			//生成预制体
			Instantiate(ZiDanGB, transform.position, transform.rotation);
        }
	}
}
