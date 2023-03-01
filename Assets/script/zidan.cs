using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zidan : MonoBehaviour {

	public float speed = 8f;//子弹速度
	// Use this for initialization
	void Start () {
		Destroy(gameObject,7f);//7s后销毁自身
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( 0,0, speed * Time.deltaTime);
	}
}
