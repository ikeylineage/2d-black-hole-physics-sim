using System.Numerics;

namespace BlackHoleSimulation.BlackHole.BlackHoleMath
{
    public class BlackHoleClass
    {
        public Vector2 PhysicsPos {get;}
        public BlackHoleClass(Vector2 pos)
        {
            PhysicsPos = pos;
        }
        public Vector2 ScreenPos =>
            PhysicsPos / Constants.metersPerPixel + new Vector2(500, 300);
    }
    public class Particle
    {
        public Vector2 PhysicsPos;
        public Vector2 Velocity;
        public double Mass {get;}

        public Particle(Vector2 startPos, double mass)
        {
            PhysicsPos = startPos;
            Mass = mass;
        }

        public Vector2 ScreenPos =>
            PhysicsPos / Constants.metersPerPixel + new Vector2(500,300);
        
        public void Update(BlackHoleClass blackHole, float dt)
        {
            Vector2 diff = blackHole.PhysicsPos - PhysicsPos; //direction from particle -> blackhole

            float distSq = BlackHoleMathHelper.DistanceSquared(PhysicsPos, blackHole.PhysicsPos);

            if (distSq < 1f)
            {
                distSq = 1f;
            }

            Vector2 direction = Vector2.Normalize(diff); //normalize direction //forces length to be 1

            float force = BlackHoleMathHelper.GravitationalForce((float)Mass, distSq);

            Vector2 acceleration = direction * (force / (float)Mass);

            Velocity += acceleration * dt;

            PhysicsPos += Velocity * dt;
        }
    }
    public static class Constants
    {
        public const double lightSpeed = 3.0e8;
        public const double gravitationalConstant = 6.674e-11;
        public const double BlackHoleMass = 1.0e35;
        public const float metersPerPixel = 1000000f;
    }
    public class BlackHoleMathHelper
    {
        public static float DistanceSquared(Vector2 a, Vector2 b)
        {
            return (a - b).LengthSquared();
        }

        public static float GravitationalForce(float particleMass, float distSq)
        {
            return (float)(Constants.gravitationalConstant * particleMass * Constants.BlackHoleMass / distSq);
        }

        public static double SchwarzschildRadius()
        {
            return 2 * Constants.gravitationalConstant * Constants.BlackHoleMass / (Constants.lightSpeed * Constants.lightSpeed);
        }
    }
}