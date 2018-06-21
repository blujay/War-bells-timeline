using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
namespace Threeyes.EventPlayer
{

    [Serializable]
    public class EventPlayerClip : PlayableAsset, ITimelineClipAsset
    {
        public ExposedReference<EventPlayer> eventPlayer;

        public ClipCaps clipCaps
        {
            get { return ClipCaps.All; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<EventPlayerBehaviour>.Create(graph);
            EventPlayerBehaviour clone = playable.GetBehaviour();
            clone.eventPlayer = eventPlayer.Resolve(graph.GetResolver());
            return playable;
        }

    }
}
