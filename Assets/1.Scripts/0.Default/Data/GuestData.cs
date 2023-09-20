using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestData : DataFrame
{
    public override void Load()
    {
        LoadCSV();
        // 게스트 정보를 유저 데이터에 불러온다.
    }

    public override void Save()
    {
        // 게스트 정보를 로컬에 저장한다.
    }
}