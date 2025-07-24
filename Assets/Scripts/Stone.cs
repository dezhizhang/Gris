using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 眼汨移动的路径
/// </summary>
public class Stone : MonoBehaviour
{
    // 隐藏显示面板
    private GameObject _tearsGo;
    // 泪点的父对像

    // 所有的泪点
    private Transform[] roadsTrans;

    // 生成眼汨的数量
    private int _tearNum;

    // 游戏物体组件
    private GameObject _grisGo;

    [HideInInspector]
    // 眼泪停止的数目
    public int stopTearNum;


    private void Start()
    {
        // // 加载文件for
        _tearsGo = Resources.Load<GameObject>("Prefabs/Tear");


        Transform pointTrans = transform.Find("Points");
        roadsTrans = new Transform[pointTrans.childCount];

        for (int i = 0; i < roadsTrans.Length; i++)
        {
            roadsTrans[i] = pointTrans.GetChild(i);
        }

        _grisGo = GameObject.Find("Gris");
        // 定时生成眼
        Invoke("StartCreatingTears", 6);
    }

    private void Update()
    {
        if (_tearNum >= 5)
        {
            CancelInvoke();
            _tearNum = 0;
        }

        if (stopTearNum >= 5)
        {
            _grisGo.AddComponent<Gris>();
            // 重新设回刚体类型
            _grisGo.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            // va
            Destroy(this);
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
        GameObject go = Instantiate(_tearsGo, roadsTrans[0].position, Quaternion.identity);
        Tear tear = go.GetComponent<Tear>();
        tear.roadsTrans = roadsTrans;
        tear.finalIndex = roadsTrans.Length - 1 - _tearNum;
        tear.stone = this;
        _tearNum++;
    }
}