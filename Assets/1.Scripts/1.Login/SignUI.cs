using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUI : MonoBehaviour
{
    public Button googleLoginButton;
    public Button guestLoginButton;

    public void Init()
    {
        var buttonGroupTransform = this.transform.Find("Root").Find("ButtonGroup").transform;
        googleLoginButton = ControlManager.NullCheck(googleLoginButton, buttonGroupTransform, nameof(googleLoginButton));
        guestLoginButton = ControlManager.NullCheck(guestLoginButton, buttonGroupTransform, nameof(guestLoginButton));

        ControlManager.SetButton(guestLoginButton, delegate { Login(LoginType.Guest); });
        ControlManager.SetButton(googleLoginButton, delegate { Login(LoginType.Google); });
    }

    public void Login(LoginType type)
    {
        DataManager.Instance.LoginData(type);
    }
}
