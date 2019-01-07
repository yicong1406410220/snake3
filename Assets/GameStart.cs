using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStart : MonoBehaviour {

    public void LoadScenMain()
    {
        SceneManager.LoadScene("Main");
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("speed")) //设置游戏速度
        {
            PlayerPrefs.SetFloat("speed", 0.5f);
        }
    }

}
