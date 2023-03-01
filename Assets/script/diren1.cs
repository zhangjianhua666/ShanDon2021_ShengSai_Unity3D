using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class diren1 : MonoBehaviour {
    public Image img;//怪兽血条
    private NavMeshAgent na;//导航组件
    public GameObject ga;//玩家，用于获取玩家坐标
    private void Start()
    {
        na = GetComponent<NavMeshAgent>();
        //na.destination = ga.transform.position;
        na.destination = new Vector3(-6.35f,15.37f,-31.89f);
    }
    private void OnTriggerEnter(Collider other)
    {
        img.fillAmount -= 0.1f;

    }
    private void Update()
    {
        if (img.fillAmount>=0.8f)
        {
            img.color = new Color(0,255,0,255);
        }
        if (img.fillAmount >= 0.4f && img.fillAmount < 0.8f)
        {
            img.color = new Color(255, 255, 0, 255);
        }
        if (img.fillAmount < 0.4f)
        {
            img.color = new Color(255, 0, 0, 255);
        }
        if (img.fillAmount==0)
        {
            
            Destroy(this.gameObject);//怪兽死亡后销毁
            XiangJiKonZhi.Add();//怪兽死亡后玩家加一分
            XiangJiKonZhi.Add();
            XiangJiKonZhi.Add();
        }
    }

}
