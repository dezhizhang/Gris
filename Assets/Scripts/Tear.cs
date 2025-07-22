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
    public int finalIndex;

    private void Update()
    {
        RoadsTransMove();
    }

    private void RoadsTransMove()
    {
        // 如果最后一个点
        if (_index == finalIndex)
        {
            if (Vector2.Distance(transform.position, roadsTrans[finalIndex].position) <= 0.1f)
            {
                
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