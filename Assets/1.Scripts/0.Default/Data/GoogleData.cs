using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleData : DataFrame
{
    public override void Load()
    {
        LoadCSV();
        // �α����� ���� ���� ������ ���� �����Ϳ� �ҷ��´�.
    }

    public override void Save()
    {
        // �α����� ���� ���� ������ DB�� �����Ѵ�.
    }
}