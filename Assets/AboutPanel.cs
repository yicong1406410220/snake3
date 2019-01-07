using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanel : MonoBehaviour {

    public void SendEmail()
    {
        string email = "1561161893@qq.com";
        string subject = MyEscapeURL("snake");
        string body = MyEscapeURL("");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    string MyEscapeURL(string url)
    {
        //%20是空格在url中的编码，这个方法将url中非法的字符转换成%20格式
        return WWW.EscapeURL(url).Replace("+", "%20");
    }

}
