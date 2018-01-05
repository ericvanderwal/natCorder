// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;
using NatCorderU.Extensions;
using NatCorderU.Examples;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Start recording using Nat Corder")]

	public class natCorderRecord : FsmStateAction
	{
     	[RequiredField]
     	[Title ("Camera")]
     	[Tooltip("Camera to use for recording.")]
		public FsmGameObject goCamera;
		
		[ActionSection ("Output")]
		[UIHint(UIHint.Variable)]
		[Tooltip("Save the recording path to a variable for playback later.")]
		public FsmString recordingPath;
		
		[Tooltip("Enable output to debug log for testing purposes.")]
		public FsmBool enableDebug;
		
		private Camera natCamera;

     	public override void Reset()
		{

			goCamera = null;
			recordingPath = null;

		}

		public override void OnEnter()
		{
			// get camera from playmaker FSM
			natCamera = goCamera.Value.GetComponent<Camera>();
			NatCorder.Verbose = true;

			if(natCamera != null)
			{
				if(enableDebug.Value)
					{
					Debug.Log("Start Camera Methods");
					}
					
				// camera found, do record
				doRecord();
			}
			
			else
			{
				if(enableDebug.Value)
				{
					Debug.Log("No Camera Found");
				}
			}
			
			Finish();

		}

		void doRecord()
		{
			
			// if not already recording, start recording
			if (!Replay.IsRecording)
			{
				if(enableDebug.Value)
				{
					Debug.Log("Recording Started");
				}
				
				Replay.StartRecording(natCamera, Configuration.Default, savePath);
			}

		}
		
		void savePath (string path) {
			
			// save path for playmaker
			recordingPath.Value = path;
			
			if(enableDebug.Value)
			{
				Debug.Log("Saved recording to: "+path);
			}
			
		}
            
     }

}