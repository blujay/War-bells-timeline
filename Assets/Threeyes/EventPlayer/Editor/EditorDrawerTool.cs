using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Threeyes.EventPlayer
{
    public static class EditorDrawerTool
    {
        //列起始位置：30(spaceSize + triangleSiz)
        //列三角形大小（不同层的间隔）：14
        public static Vector2 spaceSize = new Vector2(16, 16);//每个元素的间隔（行高）
        public static Vector2 triangleSize = new Vector2(14, 14);//展开三角形的大小
        public static Vector2 toggleSize = new Vector2(12, 12);
        public static int fontSize = 11;

        static GUIStyle _gUIStyleTransparent;
        public static Color colorTransparent = new Color(0, 0, 0, 0);
        public static Texture LoadResourcesSprite(string texName)
        {
            var sprite = Resources.Load<Sprite>("Icons/" + texName);
            if (!sprite)
                Debug.LogWarning("Null tex:" + texName);
            return sprite ? sprite.texture : null;
        }
        public static Rect GetRectAlignOnRight(Rect selectionRect, Vector2 rectSize)
        {
            Rect boxRect = new Rect(selectionRect);//selectionRect 为有效宽度
            boxRect.size = rectSize;
            Vector2 interval = (EditorDrawerTool.spaceSize - rectSize) / 2;//与四周的间隔
                                                                           //boxRect.x = (boxRect.x - (spaceSize.x + triangleSize.x)) + interval.x;// starPos + interval 左侧
            boxRect.x = selectionRect.max.x - rectSize.x - interval.x;//  右侧
            return boxRect;
        }

        public static bool CheckSelect(ref bool isMouseDown, Rect selectionRect, int buttonIndex, System.Func<bool> extraOnCondition = null)
        {
            bool isSelected = false;

            bool isMouseOn = Event.current.type == EventType.MouseDown && Event.current.button == buttonIndex;
            if (extraOnCondition != null)
                isMouseOn &= extraOnCondition();
            if (isMouseOn)
            {
                if (!isMouseDown & selectionRect.Contains(Event.current.mousePosition))
                {
                    isMouseDown = true;
                    isSelected = true;
                }
            }

            bool isMouseOff = Event.current.type == EventType.MouseUp && Event.current.button == buttonIndex;
            if (isMouseOff)
            {
                isMouseDown = false;
            }
            return isSelected;
        }

        class GUIInfo
        {
            public Color color;
            public Color contentColor;
            public Color backgroundColor;

            public void Record()
            {
                color = GUI.color;
                contentColor = GUI.contentColor;
                backgroundColor = GUI.backgroundColor;
            }
            public void Set()
            {
                GUI.color = color;
                GUI.contentColor = contentColor;
                GUI.backgroundColor = backgroundColor;
            }

        }
        static GUIInfo cacheGUIInfo = new GUIInfo();
        public static void RecordGUIColors()
        {
            cacheGUIInfo.Record();
        }
        public static void ResetGUIColors()
        {
            cacheGUIInfo.Set();
        }

    }
}