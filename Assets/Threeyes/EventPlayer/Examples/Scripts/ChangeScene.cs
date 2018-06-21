using UnityEngine;
using System.Collections.Generic;
namespace Threeyes.EventPlayer.Example
{

    public class ChangeScene : MonoBehaviour
    {
        public static ChangeScene Instance;
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        void OnGUI()
        {

            GUI.Label(new Rect(Screen.width - 120, 0, 120, 40), "Demo: " + Application.loadedLevelName);

            if (GUI.Button(new Rect(0, Screen.height - 50, 100, 40), "Last Demo"))
            {
                int nextLevel = Mathf.Abs((Application.loadedLevel + Application.levelCount - 1) % Application.levelCount);
                Application.LoadLevel(nextLevel);
            }

            if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 40), "Next Demo"))
            {
                int nextLevel = (Application.loadedLevel + 1) % Application.levelCount;
                Application.LoadLevel(nextLevel);
            }
        }

    }
}