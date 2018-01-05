// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using NatCorderU;
using NatCorderU.Core;
using NatCorderU.Extensions;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Nat Corder")]
	[Tooltip("Start playback using Nat Corder")]

	public class natCorderPlayback : FsmStateAction
	{
     	[RequiredField]
     	[Tooltip("The recording path for playback.")]
		public FsmString recordingPath;
		
		[Tooltip("Choose a background color or default to black.")]
		public FsmColor color;
		
		[Tooltip("Choose movie playback control mode. Default is full.")]
		[ObjectType(typeof(FullScreenMovieControlMode))]
		public FsmEnum fullScreenMovieControlMode;
		
		[Tooltip("Choose playback scaling mode. Default is aspect fit.")]
		[ObjectType(typeof(FullScreenMovieScalingMode))]
		public FsmEnum fullScreenMovieScalingMode;
		
		[Tooltip("Enable output to debug log for testing purposes.")]
		public FsmBool enableDebug;
		
		private string path;
		private Color _color;

     	public override void Reset()
		{
			recordingPath = null;
			path = null;
			enableDebug = false;
			color = new FsmColor {UseVariable = true};
			fullScreenMovieControlMode = new FsmEnum {UseVariable = true};
			fullScreenMovieScalingMode = new FsmEnum {UseVariable = true};
		}

		public override void OnEnter()
		{
			doPlayback();
			Finish();
		}

		void doPlayback()
		{
			path = recordingPath.Value;
			if(path == null)
			{
				return;
			}
			
			if(color.IsNone)
			{
				_color = Color.black;
			}
			
			else 
			{
				_color = color.Value;
			}
			
			if(fullScreenMovieControlMode.IsNone)
			{
				fullScreenMovieControlMode.Value = FullScreenMovieControlMode.Full;
			}

			if(fullScreenMovieScalingMode.IsNone)
			{
				fullScreenMovieScalingMode.Value = FullScreenMovieScalingMode.AspectFill;
			}
			
			
			Handheld.PlayFullScreenMovie(path, _color, (FullScreenMovieControlMode)fullScreenMovieControlMode.Value, (FullScreenMovieScalingMode)fullScreenMovieScalingMode.Value);
			
			if(enableDebug.Value)
			{
				Debug.Log("Playback has started.");
			}
			
		}
            
     }

}