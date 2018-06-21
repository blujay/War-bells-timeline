___________________________________

		 	 EventPlayer
			 by Threeyes
___________________________________

* How to test the demos?
	Add all scenes to the Build Setting,  then hit play! You can see the Explanation on the [Remarker] Component.

	
*How to use EventPlayer?
	Just assign Method to the EventPlayer/TempEventPlayer/DelayEventPlayer/RepeatEventPlayer/EventPlayerGroup¡­ 
	Component Interface, and Invoke ¡°Play/Stop", isn't that easy?

*What's that littly ugly GUIToggle in Hierarchy Window, once I add EventPlayer Component to a GameObject?
	It can help you easily change property or Invoke Method of EventPlayer without using the Inspector Window, you can try this:
	- Press the GUIToggle (or just hover the GameObject and  press the middle mouse button) to Invoke EventPlayer.TogglePlay Method, 
	it will also show that if the EventPlayer is played;
	- Hover the GameObject and  Alt+Click to switch IsActive state;

*I hate creating empty GameObject! Any ShorCuts?
	- Shift+Ctrl+E: Create EventPlayer in the same hierarchy layer
	- Shift+Alt+E: Create EventPlayer as Child
	- Shift+Ctrl+G: Create EventPlayerGroup in the same hierarchy layer
	- Shift+Alt+G: Create EventPlayerGroup as Child


* Support platform?
	Since I only use the Unity Buildin EventSystem, it may support as many platform as possible.

* Don't need the TimelineExtension or your Unity Version does't support Timeline?
	Just Delete the "Timeline Extension" Folder, you are good to go.


---------------------------   
      Version History      
---------------------------  

-1.4
1. I am so sorry for the inconvenient, but I have to rename RepeatPlayer.duration to RepeatPlayer.defaultDuration,
you may need to reassign this property, hope that don't bring you a lot of trouble.
2.Add Extra EditorGUI for TimelineEventPlayer, now it can show the playable info such as time or duration.

-1.3
1. Add Extra EditorGUI for EventPlayer, easier to modify property without using Inspector Window

- 1.2
1. Small UI improvement
2. Replace System.Action with UnityAction

- 1.1
Fix bug

- 1.0
First release