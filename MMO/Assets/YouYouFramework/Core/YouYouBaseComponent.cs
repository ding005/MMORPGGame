using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public abstract class YouYouBaseComponent : YouYouComponent
    {
        protected override void OnAwake()
        {
            base.OnAwake();

            //把自己加入基础组件列表
            //GameEntry.RegisterBaseComponent(this);
        }
    }
}