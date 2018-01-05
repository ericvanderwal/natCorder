// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Pause recording of Nat Corder")]

	public class natCorderPause : FsmStateAction
	{
		
		public override void OnEnter()
		{
			doPause();
			Finish();
		}

		void doPause()
		{
			Replay.PauseRecording();
		}
     }
}