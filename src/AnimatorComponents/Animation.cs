using System;
using System.Collections.Generic;
using System.Text;

namespace TestExample.src.AnimatorComponents
{
    class Animation
    {
        string name;
        int startRow;
        int endRow; // Or start row by default
        int startColumn;
        int endColumn; // Or last column by default;
        float timeBetweenFrames;
        bool isPlaying = false;

        float currentTime = 0;
        int currentColumn;
        int currentRow;

        public Animation(string name, int startRow, int endRow, int startColumn, int endColumn, float timeBetweenFrames)
        {
            this.name = name;
            this.startRow = startRow;
            this.endRow = endRow == null || endRow == 0 ? startRow : endRow;
            this.startColumn = startColumn;
            this.currentColumn = startColumn;
            this.endColumn = endColumn;
            this.timeBetweenFrames = timeBetweenFrames;
        }

        // Getters
        public string GetName()
        {
            return this.name;
        }

        public int GetCurrentColumn()
        {
            return this.currentColumn;
        }

        public int GetCurrentRow()
        {
            return this.currentRow;
        }

        public void Play()
        {
            this.isPlaying = true;    
        }

        // Update
        public void Update(float dt)
        {
            this.currentTime += dt;

            if (this.currentTime > this.timeBetweenFrames)
            {
                this.currentTime = 0;

                this.currentColumn++;
                Console.WriteLine(this.currentColumn);
                if (this.currentColumn >= this.endColumn && this.startRow == this.endRow)
                {
                    this.currentColumn = this.startColumn;
                    this.currentRow = this.startRow;
                }
                else if (this.currentColumn >= this.endColumn && this.startRow != this.endRow)
                {
                    this.currentColumn = this.startColumn;
                    this.currentRow++;
                }
            }
        }
    }
}
