using Raylib_cs;
using BlackHoleSimulation.BlackHole.BlackHoleMath;
using System.Numerics;

namespace BlackHoleSimulation
{
    public class SetUp
    {
        public BlackHoleClass blackHole {get; private set;}
        public List<Particle> particles {get; private set;}
        public void SettingUp()
        {
            blackHole = new BlackHoleClass(new Vector2(0,0));

            particles = new List<Particle>();
            
                for (int i = 0; i < 10; i++)
                {
                    float screenX = 100f;
                    float screenY = 50f + i * 55f;

                    Vector2 physicsPos = (new Vector2(screenX, screenY) - new Vector2(500, 300)) * Constants.metersPerPixel;

                    var p = new Particle(physicsPos, 1.0)
                    {
                        Velocity = new Vector2(80_000f, 100000f) //push to the right
                    };

                    particles.Add(p);
                }

                
            }
        }
    
    public static class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(800, 600, "BlackHoleSimulation");
            Raylib.SetTargetFPS(60);

            SetUp world = new SetUp();
            world.SettingUp();

            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();


                foreach (var p in world.particles)
                {
                    p.Update(world.blackHole, dt);
                }

                double rs = BlackHoleMathHelper.SchwarzschildRadius();

                for (int i = world.particles.Count - 1; i >= 0; i--)
                {
                    double distance = Vector2.Distance(world.particles[i].PhysicsPos, world.blackHole.PhysicsPos);

                    if (distance < rs)
                    {
                        world.particles.RemoveAt(i);
                    }
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                Raylib.DrawCircleV(world.blackHole.ScreenPos, 60, Color.RayWhite);

                foreach (var p in world.particles)
                {
                    Raylib.DrawCircleV(p.ScreenPos, 3, Color.SkyBlue);
                }
                
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
   }   
}   
