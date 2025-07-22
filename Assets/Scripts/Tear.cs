using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 眼泪方法
/// </summary>
public class Tear : MonoBehaviour
{
    // 所有的泪点
    public Transform[] roadsTrans;

    private int _index;

    // 最后一个点的位置
    public int finalIndex;

    public Stone stone;

    // 无目标移动
    public bool notTargetMove;

    // 眼泪移动的速度
    private float _moveSpeed;

    // 旋转角度
    private float _rotateAngle;

    private void Start()
    {
        _moveSpeed = 5;
        _rotateAngle = 30;
    }

    private void Update()
    {
        RoadsTransMove();
    }

    private void RoadsTransMove()
    {
        if (notTargetMove)
        {
            if (stone.stopTearNum >= 5)
            {
                // 沿着某一个方向无目标点移动
                transform.Translate(transform.right * _moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            // 朝着某一个固定目标点移动
            if (_index == finalIndex)
            {
                if (Vector2.Distance(transform.position, roadsTrans[finalIndex].position) <= 0.1f)
                {
                    stone.stopTearNum++;
                    // 切换状态
                    notTargetMove = true;
                    transform.Rotate(new Vector3(0, 0, _rotateAngle * finalIndex));
                    return;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, roadsTrans[_index + 1].position, 0.02f);
                if (Vector2.Distance(transform.position, roadsTrans[_index + 1].position) <= 0.1f)
                {
                    _index++;
                }
            }
        }
    }
}