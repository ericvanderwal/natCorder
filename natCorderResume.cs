// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Resume recording after a pause of Nat Corder")]

	public class natCorderResume : FsmStateAction
	{
		
		public override void OnEnter()
		{
			doResume();
			Finish();
		}

		void doResume()
		{
			Replay.ResumeRecording();
		}
     }
}