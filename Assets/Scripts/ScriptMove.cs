
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class NewBehaviourScript : MonoBehaviour
{
  private Transform _transSp1;

  // 移动步频
  public float movePercent = 0.01f;
  private void Start()
  {
    _transSp1 = GameObject.Find("Script1").transform;
  }

  private void Update()
  {
    transform.position = Vector2.MoveTowards(transform.position,_transSp1.position,movePercent);
  }
}
