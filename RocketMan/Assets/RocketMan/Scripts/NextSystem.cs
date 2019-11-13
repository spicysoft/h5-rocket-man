using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;

namespace RocketMan
{
    public class NextSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.nextSystem)
                return;
            config.nextSystem = false;
            config.RandomSet = true;
            config.Rounds++;
            config.answerDirectiion.Value = new float3(0, -12, 0);
            Entities.ForEach((Entity entity, ref Planet planet, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 1;
            });

            Entities.ForEach((Entity entity, ref Rocket rocket, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });

            tinyEnv.SetConfigData(config);
        }
    }
}


