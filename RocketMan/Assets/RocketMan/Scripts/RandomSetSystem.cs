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
            Entities.ForEach((Entity wallEntity, ref Planet planet, ref Translation Transform) =>
            {
                Transform.Value = _random.NextInt3(new int3(x: -20, y: -20, z: 0), new int3(x: 20, y: 20, z: 0));
            });
            tinyEnv.SetConfigData(config);
        }
    }
}

