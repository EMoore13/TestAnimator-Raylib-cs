using System;
using System.Linq;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

// Test Reading JSON file from Tiled
using Newtonsoft.Json;

// Testing animator
using TestExample.AnimatorRaylib_cs;
using TestExample.src.AnimatorComponents;
using System.Collections.Generic;

namespace TestExample
{   
    class Program
    {
        const string resourcePath = "PATH TO DIRECTORY";

        static void Main(string[] args)
        {
            const int screenW = 800;
            const int screenH = 600;

            InitWindow(screenW, screenH, "Testing Library");

            // Load Texture
            Texture2D mainCharacterSprite = LoadTexture(resourcePath + "CharSheetEdit.png");
            Rectangle mainCharacterFrameRec = new Rectangle(0, 0, 84, 64);

            TestAnimator animator = new TestAnimator(mainCharacterSprite, mainCharacterFrameRec, 24, 1);
            List<AnimationClip> RunFrames = new List<AnimationClip>();
            RunFrames.Add(new AnimationClip(8, 16, 1));
            RunFrames.Add(new AnimationClip(1, 7, 1));
            animator.AddAnimation("RunAndAttack", RunFrames, 0.1f);

            SetTargetFPS(60);

            while(!WindowShouldClose())
            {
                animator.Update();

                //Draw
                BeginDrawing();
                ClearBackground(Color.BLACK);

                DrawTexturePro(mainCharacterSprite, animator.GetFrameRec(), new Rectangle(0, 0, 168, 128), new Vector2(0, 0), 0, Color.WHITE);

                EndDrawing();
            }
        }
    }
}
