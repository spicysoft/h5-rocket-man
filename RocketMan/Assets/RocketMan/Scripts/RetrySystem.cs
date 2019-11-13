using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;


namespace RocketMan
{
    public class RetrySystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.retrySystem)
                return;
            config.retrySystem = false;
            config.Rounds = 0;
            config.Score = 0;
            config.answerDirectiion.Value = new float3(0, -config.YRandomMax, 0);
            Entities.ForEach((Entity entity, ref Planet planet, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref StartButton startButton, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 1;
            });
            Entities.ForEach((Entity entity, ref Rocket rocket, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref Title title, ref Translation Transform, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 1;

            });
            Entities.ForEach((Entity _entity, ref GameOverTitle gameOver, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            tinyEnv.SetConfigData(config);
        }
    }
}

