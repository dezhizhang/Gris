using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 眼汨移动的路径
/// </summary>
public class Stone : MonoBehaviour
{
    private GameObject _tearsGo;
    // 泪点的父对像

    // 所有的泪点
    private Transform[] roadsTrans;


    private void Start()
    {
        // 加载文件for
        _tearsGo = Resources.Load<GameObject>("Prefabs/tears");
        Transform pointTrans = transform.Find("Points");
        roadsTrans = new Transform[pointTrans.childCount];

        for (int i = 0; i < roadsTrans.Length; i++)
        {
            // 获取所有的路点
            roadsTrans[i] = pointTrans.GetChild(i);
        }
    }
}