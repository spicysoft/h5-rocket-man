using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;

namespace RocketMan
{
    public class RandomSetSystem : ComponentSystem
    {
        private Random _random;

        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();
        }
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.RandomSet)
                return;

            config.RandomSet = false;


            Entities.ForEach((Entity entity, ref Planet planet, ref Translation Transform, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 1;
                Transform.Value = _random.NextInt3(new int3(x: -10, y: -10, z: 0), new int3(x: 10, y: 10, z: 0));
                config.PlanetLocation = Transform;
            });

            config.WaitforSeconds = true;
            tinyEnv.SetConfigData(config);
        }
    }
}

