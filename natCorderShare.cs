// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;
using NatCorderU.Extensions;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Share Nat Corder recording with native device share.")]

	public class natCorderShare : FsmStateAction
	{
     	[RequiredField]
     	[Tooltip("The recording path for sharing.")]
     	[UIHint(UIHint.Variable)]
		public FsmString recordingPath;
		
		private string path;

     	public override void Reset()
		{
			recordingPath = null;
			path = null;

		}

		public override void OnEnter()
		{
			doShare();
			Finish();
		}

		void doShare()
		{
			path = recordingPath.Value;
			if(path == null)
			{
				return;
			}
			
			Sharing.Share(path);
			
		}
            
     }

}