// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;
using NatCorderU.Extensions;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Check to see if Nat Corder is recording")]

	public class natCorderRecordingCheck : FsmStateAction
	{

		[UIHint(UIHint.Variable)]
		[Tooltip("True if recording, false if not recording.")]
		public FsmBool isRecording;
		
		public FsmBool everyframe;
		
		public FsmBool enableDebug;

     	public override void Reset()
		{

			isRecording = false;
			everyframe = false;
			enableDebug = false;

		}

		public override void OnEnter()
		{
			
			doCheck();
			
			if (!everyframe.Value)
			{
				Finish();
			}

		}
		
		public override void OnUpdate()
		{
			if (everyframe.Value)
			{
				doCheck();
			}
		}

		void doCheck()
		{
			
			isRecording.Value = Replay.IsRecording;
			
			if(enableDebug.Value)
			{
				Debug.Log("Video currently recording = " + isRecording.Value);
			}
			
		}
     }

}