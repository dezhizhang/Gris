using UnityEngine;

/// <summary>
/// gris移动
/// </summary>
public class ScriptMove : MonoBehaviour
{
    // 移动到空物体位置
    private Transform _transSp1;

    // 移动步频
    public float movePercent = 0.01f;

    private Animator _animator;

    private void Start()
    {
        _transSp1 = GameObject.Find("Script1").transform;
        _animator = GetComponent<Animator>();
        // 播放Walk动画
        _animator.Play("Walk");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _transSp1.position, movePercent);
        if (Vector3.Distance(transform.position, _transSp1.position) <= 0.01)
        {
            Destroy(this);
        }
    }
}