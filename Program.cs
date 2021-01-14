using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

// Test Reading JSON file from Tiled
using Newtonsoft.Json;

// Testing animator
using TestExample.AnimatorRaylib_cs;

namespace TestExample
{   
    class Program
    {
        const string resourcePath = "C:/Users/Ezzy Poo/dev/raylib_cs/LibraryTesting/TestExample/Resources/";

        static void Main(string[] args)
        {
            const int screenW = 800;
            const int screenH = 600;

            InitWindow(screenW, screenH, "Testing Library");

            // Load Texture
            Texture2D mainCharacterSprite = LoadTexture(resourcePath + "CharSheetEdit.png");
            Rectangle mainCharacterFrameRec = new Rectangle(0, 0, 84, 64);

            TestAnimator animator = new TestAnimator(mainCharacterSprite, mainCharacterFrameRec, 24, 1);
            animator.AddAnimation("test", 1, 1, 8, 16, 0.1f);
            animator.AddAnimation("Attack", 1, 1, 0, 8, 0.1f);

            // Another test animations with rows
            Texture2D ojaSprite = LoadTexture(resourcePath + "Yemoja.png");
            Rectangle ojaFrameRec = new Rectangle(0, 0, 80, 54);

            TestAnimator ojaAnimator = new TestAnimator(ojaSprite, ojaFrameRec, 12, 11);
            ojaAnimator.AddAnimation("idle", 1, 1, 0, 12, 0.2f);
            ojaAnimator.AddAnimation("Attack", 5, 6, 7, 3, 0.2f);
            ojaAnimator.SetCurrentAnim("Attack");

            SetTargetFPS(60);

            while(!WindowShouldClose())
            {
                //Updates
                if (IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    if (animator.GetCurrentAnimName() == "test")
                        animator.SetCurrentAnim("Attack");
                    else if (animator.GetCurrentAnimName() == "test")
                        animator.SetCurrentAnim("test");
                    else
                        animator.SetCurrentAnim("test");
                }

                animator.Update();
                ojaAnimator.Update();

                //Draw
                BeginDrawing();
                ClearBackground(Color.BLACK);

                DrawTexturePro(mainCharacterSprite, animator.GetFrameRec(), new Rectangle(0, 0, 168, 128), new Vector2(0, 0), 0, Color.WHITE);
                DrawTexturePro(ojaSprite, ojaAnimator.GetFrameRec(), new Rectangle(200, 0, 160, 108), new Vector2(0, 0), 0, Color.WHITE);

                EndDrawing();
            }
        }
    }
}
