using System;
using System.Collections.Generic;
using System.Text;

namespace TestExample.src.AnimatorComponents
{
    class AnimationClip
    {
        int startCol;
        int endCol;
        int row;

        public AnimationClip(int startColumn, int endColumn, int row)
        {
            this.startCol = startColumn;
            this.endCol = endColumn;
            this.row = row;
        }

        public int GetStartColumn()
        {
            return this.startCol;
        }

        public int GetEndColumn()
        {
            return this.endCol;
        }

        public int GetRow()
        {
            return this.row;
        }
    }
}
