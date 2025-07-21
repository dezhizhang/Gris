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

    // 生成眼汨的数量
    private int _tearNum;


    private void Start()
    {
        // 加载文件for
        _tearsGo = Resources.Load<GameObject>("Prefabs/tears");
        Transform pointTrans = transform.Find("Points");
        roadsTrans = new Transform[pointTrans.childCount];

        // 定时生成眼
        Invoke("StartCreatingTears", 6);
    }

    private void Update()
    {
        if (_tearNum >= 5)
        {
            _tearNum = 0;
            CancelInvoke("StartCreatingTears");
        }
    }

    /// <summary>
    /// 生成眼汨的方法
    /// </summary>
    private void StartCreatingTears()
    {
        InvokeRepeating("CreateTear", 0, 2);
    }

    /// <summary>
    ///  生成眼汨
    /// </summary>
    private void CreateTear()
    {
        _tearNum++;
        Instantiate(_tearsGo, roadsTrans[0]);
    }
}