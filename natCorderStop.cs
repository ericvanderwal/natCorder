// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Stop recording of Nat Corder")]

	public class natCorderStop : FsmStateAction
	{
		
		public override void OnEnter()
		{

			doStop();
			Finish();

		}

		void doStop()
		{
			
			Replay.StopRecording();

		}
     }
}