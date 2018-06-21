using UnityEngine;

namespace Threeyes.EventPlayer.Example
{
    /// <summary>
    ///挂在游戏物体上，作为备注
    /// </summary>
    public class InfoLogger : MonoBehaviour
    {
        [Multiline]
        public string tips;

        public void Print(float value)
        {
            Debug.Log(tips + value);
        }
        public void Print(string str)
        {
            Debug.Log(str);
        }
        public void PrintInfo()
        {
            Debug.Log(name + ": " + tips + "\r\n");//need some spaces
        }
    }
}