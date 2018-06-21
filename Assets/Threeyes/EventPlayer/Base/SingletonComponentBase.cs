using UnityEngine;

namespace Threeyes.EventPlayer
{
    /// <summary>
    /// Singleton
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonComponentBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T _Instance;
        public static T Instance
        {
            get
            {
                if (!_Instance)
                {
                    GameObject newGo = new GameObject(typeof(T).ToString(), typeof(T));
                    _Instance = newGo.GetComponent<T>();
                    DontDestroyOnLoad(newGo);
                }
                return _Instance;
            }
        }
    }
}