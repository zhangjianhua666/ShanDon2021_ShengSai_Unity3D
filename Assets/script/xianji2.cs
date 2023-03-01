using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xianji2 : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="di")
        {
            Destroy(other);
            Debug.Log("销毁一个物体di");
        }
        
    }
}
