using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingPanel : MonoBehaviour {

    public Slider slider;


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("speed"))
        {
            float value = PlayerPrefs.GetFloat("speed", 0);
            slider.value = value;
        }
        else
        {
            PlayerPrefs.SetFloat("speed", 0.5f);
            slider.value = 0.5f;
        } 
	}
	
    public void SetSliderValue(float v)
    {
        PlayerPrefs.SetFloat("speed", v);
        slider.value = v;     
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

}
