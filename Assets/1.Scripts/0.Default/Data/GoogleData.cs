using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleData : DataFrame
{
    public override void Load()
    {
        LoadCSV();
        // 로그인한 구글 계정 정보를 유저 데이터에 불러온다.
    }

    public override void Save()
    {
        // 로그인한 구글 계정 정보를 DB에 저장한다.
    }
}