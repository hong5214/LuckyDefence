using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultObject : MonoBehaviour
{
    public void Awake()
    {
        var obj = FindObjectsOfType<DefaultObject>();
        if (obj.Length == 1)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);
    }
}
