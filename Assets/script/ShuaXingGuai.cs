using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuaXingGuai : MonoBehaviour {
    /// <summary>
    /// 怪物预制体
    /// </summary>
    public GameObject GWga;
    /// <summary>
    /// 刷新点组
    /// </summary>
    public GameObject[] ShuaXingD;
    /// <summary>
    /// 计时器
    /// </summary>
    private float time=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time>=5)//五秒刷新一次
        {
            for (int i = 0; i < ShuaXingD.Length; i++)
            {
                Instantiate(GWga, ShuaXingD[i].transform.position, ShuaXingD[i].transform.rotation);
            }
            time = 0;
        }
        
	}
}
