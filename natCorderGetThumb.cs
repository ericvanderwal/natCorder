// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;
using NatCorderU.Extensions;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Get Nat Corder recording thumbnail.")]

	public class natCorderGetThumb : FsmStateAction
	{
     	[RequiredField]
     	[Tooltip("The recording path.")]
     	[UIHint(UIHint.Variable)]
		public FsmString recordingPath;
		
		[RequiredField]
		[Tooltip("Thumbnail object.")]
		[UIHint(UIHint.Variable)]
		public FsmTexture thumbnail;
		
		private string path;
		private Texture2D texture2d;
		private Texture texture;

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
			
			texture2d = Sharing.GetThumbnail(path);
			texture = texture2d;
			thumbnail.Value = texture;
		}
            
     }

}