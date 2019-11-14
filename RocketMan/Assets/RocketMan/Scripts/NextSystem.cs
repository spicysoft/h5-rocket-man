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
            if(config.Rounds >= 5)
            {
                config.distance = 0.75f;
            }
            config.answerDirectiion.Value = new float3(0, -config.YRandomMax, 0);
            Entities.ForEach((Entity entity, ref Planet planet, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform,ref Sprite2DRendererOptions sprite2DRendererOptions) =>
            {
                
                sprite2DRenderer.color.a = 1;
                if (config.Rounds >= 5)
                {
                    sprite2DRenderer.color = new Color(0.7647059f, 0.3490196f, 0.713506f);
                    sprite2DRendererOptions.size = new float2(1.5f, 1.5f);
                }
            });
            Entities.ForEach((Entity entity, ref Rocket rocket, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity _entity, ref Success success, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            tinyEnv.SetConfigData(config);
        }
    }
}


