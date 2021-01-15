using System;
using System.Collections.Generic;
using TestExample.src.AnimatorComponents;

namespace TestExample.src.AnimatorComponents
{
    class Animation
    {
        string name;
        List<AnimationClip> animationClipList = new List<AnimationClip>();
        int currentCol;
        int currentR;
        int endCol;
        int currentIndex;

        float timeBetweenFrames;
        bool isPlaying = true;

        float currentTime = 0;

        public Animation(string name, List<AnimationClip> animFrames, float timeBetweenFrames)
        {
            this.name = name;
            this.animationClipList = animFrames;
            this.timeBetweenFrames = timeBetweenFrames;
            this.currentIndex = 0;

            this.currentCol = this.animationClipList[this.currentIndex].GetStartColumn();
            this.endCol = this.animationClipList[this.currentIndex].GetEndColumn();
            this.currentR = this.animationClipList[this.currentIndex].GetRow();
        }

        // Getters
        public string GetName()
        {
            return this.name;
        }

        public int GetCurrentColumn()
        {
            return this.currentCol;
        }

        public int GetCurrentRow()
        {
            return this.currentR;
        }

        public void Play()
        {
            this.isPlaying = true;
        }

        public bool GetIsPlaying()
        {
            return this.isPlaying;
        }

        public void Pause()
        {
            this.isPlaying = false;
        }

        public void Stop()
        {
            this.isPlaying = false;

            this.currentTime = 0;
            this.currentIndex = 0;
            this.currentCol = this.animationClipList[this.currentIndex].GetStartColumn();
            this.endCol = this.animationClipList[this.currentIndex].GetEndColumn();
            this.currentR = this.animationClipList[this.currentIndex].GetRow();
        }

        // Update
        public void Update(float dt)
        {
            if (this.isPlaying)
            {
                this.currentTime += dt;

                // REWRITE
                if (this.currentTime > this.timeBetweenFrames)
                {
                    this.currentTime = 0f;

                    this.currentCol++;
                    if (this.currentCol >= this.endCol)
                    {
                        this.currentIndex++;
                        if (this.currentIndex < animationClipList.Count)
                        {
                            this.currentCol = this.animationClipList[this.currentIndex].GetStartColumn();
                            this.endCol = this.animationClipList[this.currentIndex].GetEndColumn();
                            this.currentR = this.animationClipList[this.currentIndex].GetRow();
                        }
                        else
                        {
                            this.currentIndex = 0;

                            this.currentCol = this.animationClipList[this.currentIndex].GetStartColumn();
                            this.endCol = this.animationClipList[this.currentIndex].GetEndColumn();
                            this.currentR = this.animationClipList[this.currentIndex].GetRow();
                        }
                    }
                }
            }
        }
    }
}
