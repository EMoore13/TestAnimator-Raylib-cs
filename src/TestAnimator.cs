using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;
using TestExample.src.AnimatorComponents;

namespace TestExample.AnimatorRaylib_cs
{
	class TestAnimator
	{
		// TODO: ADD CLASS VARIABLES
		// ------------------------------------------------------------------ //
		Texture2D sprite;
		Rectangle frameRec;

		int columns;
		int rows;
		int imageWidth;
		int imageHeight;

		List<Animation> animations = new List<Animation>();
		Animation currentAnimation;


		// STEP 1: CONSTRUCT, WHAT VARIABLES ARE NEEDED?
		//		FOR DRAWING:
		//		- Texture2D texture 
		//		- Rectangle frameRec

		//		Add frameRec.width or frameRec.height to frameWidth to go to next frame
		//		return to 0 at last row/column
		// ------------------------------------------------------------------ //
		public TestAnimator(Texture2D sprite, Rectangle frameRec, int columns, int rows)
		{
			this.sprite = sprite;
			this.frameRec = frameRec;
			this.columns = columns > 0 ? columns : 1;
			this.rows = rows > 0 ? rows : 1;

			GetImageSize(frameRec.width, frameRec.height, this.columns, this.rows);
		}

		// Getters
		public Texture2D GetSprite()
        {
			return this.sprite;
        }

		public Rectangle GetFrameRec()
        {
			return this.frameRec;
        }

		public int GetColumns()
        {
			return this.columns;
        }

		public int GetRows()
        {
			return this.rows;
        }

		public bool GetIsPlaying()
        {
			return this.currentAnimation.GetIsPlaying();
        }

		public void Play()
		{
			this.currentAnimation.Play();
		}

		public void Pause()
		{
			this.currentAnimation.Pause();
		}

		public void Stop()
		{
			this.currentAnimation.Stop();
		}

		void GetImageSize(float width, float height, int col, int row)
        {
			this.imageWidth = (int)width * col;
			this.imageHeight = (int)height * row;
        }

		public void AddAnimation(string n, List<AnimationClip> anims, float tBF)
		{
			Animation anim = new Animation(n, anims, tBF);
			animations.Add(anim);

			if (this.currentAnimation == null)
				SetCurrentAnim(anim.GetName());
        }

		public void SetCurrentAnim(string n)
        {
			this.currentAnimation = animations.Find(a => a.GetName() == n);
        }
		public string GetCurrentAnimName()
		{
			return this.currentAnimation.GetName();
		}

		public void Update()
        {
			if (this.currentAnimation != null)
			{
				this.currentAnimation.Update(GetFrameTime());
				this.frameRec = new Rectangle(this.frameRec.width * this.currentAnimation.GetCurrentColumn(), this.frameRec.height * this.currentAnimation.GetCurrentRow(), this.frameRec.width, this.frameRec.height);
			}
		}
	}
}
