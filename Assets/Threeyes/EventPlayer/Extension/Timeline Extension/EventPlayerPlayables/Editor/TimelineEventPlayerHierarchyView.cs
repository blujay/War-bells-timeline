#if UNITY_EDITOR

using System.Text;
namespace Threeyes.EventPlayer
{

    /// <summary>
    /// Ref:
    /// http://ilkinulas.github.io/unity/2016/07/20/customize-unity-hierarchy-window.html
    /// https://forum.unity.com/threads/colors-colors-and-more-colors-please.499150/
    /// </summary>
    public static partial class EventPlayerHierarchyView
    {
        static StringBuilder sbTL = new StringBuilder();
        static partial void DrawTimelineEventPlayer(EventPlayer ep, ref string texProperty, ref string texEPType)
        {
            TimelineEventPlayer tlEP = ep as TimelineEventPlayer;
            if (tlEP)
            {
                sbTL.Length = 0;
                texEPType += "TL";
                sbTL.Append((tlEP.playableInfo.time * 100).ToString("00:00") + "/" + (tlEP.playableInfo.duration * 100).ToString("00:00"));
                AddSplit(ref texProperty, sbTL.ToString());
            }
        }
    }

}
#endif