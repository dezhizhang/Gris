using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
   private GameObject _tearsGo;

   private void Start()
   {
      // 加载文件
      _tearsGo = Resources.Load<GameObject>("Prefabs/tears");
      
      
      
   }

}
