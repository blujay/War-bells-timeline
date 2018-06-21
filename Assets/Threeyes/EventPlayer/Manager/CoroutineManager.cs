using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Threeyes.EventPlayer
{

    /// <summary>
    /// Use this Instance to Start Coroutine
    /// </summary>
    public class CoroutineManager : SingletonComponentBase<CoroutineManager>
    {
        public static Coroutine StartCoroutineEx(IEnumerator routine)
        {
            if (Application.isPlaying)
            {
                return Instance.StartCoroutine(routine);
            }
            else
            {
                return null;
            }
        }

        public static void StopCoroutineEx(Coroutine routine)
        {
            if (Application.isPlaying)
            {
                Instance.StopCoroutine(routine);
            }
        }
    }
}