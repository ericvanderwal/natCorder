// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;
using NatCorderU.Extensions;

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
		
		[ActionSection ("Options")]
		
		[Tooltip("Optionally choose the game object with the audio listener. If none is chosen, no audio will be recorded")]
		public FsmGameObject audioListener;
		
		[Tooltip("Enable output to debug log for testing purposes.")]
		public FsmBool enableDebug;
		
		private Camera natCamera;
		private AudioListener _audioListener;

     	public override void Reset()
		{

			goCamera = null;
			recordingPath = null;
			audioListener = new FsmGameObject {UseVariable = true};
			_audioListener = null;
			natCamera = null;

		}

		public override void OnEnter()
		{
			// get camera from playmaker FSM
			natCamera = goCamera.Value.GetComponent<Camera>();
			NatCorder.Verbose = true;
			
			if(!audioListener.IsNone)
			{
				_audioListener = audioListener.Value.GetComponent<AudioListener>();
			}
			
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
				// debug log
				if(enableDebug.Value)
				{
					Debug.Log("Recording Started");
				}
				
				// record without sound
				if(audioListener.IsNone)
				{
					Replay.StartRecording(natCamera, Configuration.Default, savePath);
				}
				
				// record with sound
				if(!audioListener.IsNone)
				{
					Replay.StartRecording(natCamera, Configuration.Default, savePath, _audioListener);
				}
			}

		}
		
		void savePath (string path) {
			
			// save path for playmaker
			recordingPath.Value = path;
			
			// debug log
			if(enableDebug.Value)
			{
				Debug.Log("Saved recording to: "+path);
			}
			
		}
            
     }

}