using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtClc : MonoBehaviour {
    /// <summary>
    /// 关闭游戏
    /// </summary>
    public void offButt() {
        Application.Quit();
    }
    /// <summary>
    /// 重新游戏
    /// </summary>
    public void chonQiButt() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }
}
