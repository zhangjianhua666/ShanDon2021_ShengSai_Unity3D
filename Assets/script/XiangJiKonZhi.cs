using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XiangJiKonZhi : MonoBehaviour {
    /// <summary>
    /// 显示分数组件
    /// </summary>
    public Text txt;
    /// <summary>
    /// 积分
    /// </summary>
    private static int num=0;
    /// <summary>
    /// 游戏成功UI
    /// </summary>
    public GameObject UICG;
    /// <summary>
    /// 失败界面
    /// </summary>
    public GameObject UISB;
    /// <summary>
    /// 菜单界面
    /// </summary>
    public GameObject UICD;
    /// <summary>
    /// 血条界面
    /// </summary>
    public Image xueTiao;

    /// <summary>
    /// 主相机
    /// </summary>
    public GameObject mianXiangJi;
    /// <summary>
    /// 二号相机
    /// </summary>
    public GameObject XiangJI2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = num + "/30";
        if (num>=30)
        {
            UICD.SetActive(false);
            UICG.SetActive(true);
            mianXiangJi.SetActive(false);
            XiangJI2.SetActive(true);
            num = 0;

        }
		float mouseX = Input.GetAxis("Mouse X") * 10.0f;
		float mouseY = Input.GetAxis("Mouse Y") * 10.0f;
		//Camera.main.transform.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(-mouseY,0,0);
		Camera.main.transform.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(0, mouseX, 0);
        if (xueTiao.fillAmount<=0)
        {
            UICD.SetActive(false);
            UISB.SetActive(true);
            mianXiangJi.SetActive(false);
            XiangJI2.SetActive(true);
        }
	}
    /// <summary>
    /// 加分方法
    /// </summary>
    public static void Add() {
        num++;
    }
    /// <summary>
    /// 碰撞一下减一分
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        xueTiao.fillAmount -= 0.1f;
        Destroy(other.gameObject);
    }
}
