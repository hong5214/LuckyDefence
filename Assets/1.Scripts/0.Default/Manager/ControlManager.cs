using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ControlManager
{
    public static T NullCheck<T>(T checkObj, Transform checkTransform, string objectName)
    {
        if (checkObj == null) checkObj = checkTransform.Find(objectName).GetComponent<T>();
        return checkObj;
    }

    public static void ShowLog(string logText)
    {
        Debug.Log(logText);
    }

    public static void SetButton(Button button, Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener( delegate { action.Invoke(); });
    }
}
