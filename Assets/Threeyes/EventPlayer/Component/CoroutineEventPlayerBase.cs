using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Threeyes.EventPlayer
{
    public abstract class CoroutineEventPlayerBase : EventPlayer
    {
        protected Coroutine cacheEnum;

        protected void TryStopCoroutine()
        {
            if (cacheEnum != null)
                CoroutineManager.StopCoroutineEx(cacheEnum);
        }
    }
}