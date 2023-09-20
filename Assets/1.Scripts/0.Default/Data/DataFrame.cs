using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataFrame
{
    public abstract void Save();
    public abstract void Load();

    public void LoadCSV()
    {
        // csv 데이터 로드
    }
}
