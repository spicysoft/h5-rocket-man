using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;
namespace RocketMan
{

    public class LaunchSystem : ComponentSystem
    {
        float speed = 20;
        float3 direction = new float3(0, 1, 0);

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();


            if (!config.launchSystem)
                return;

            Entities.ForEach((Entity entity, ref Fire fire, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 1;
            });
            Entities.ForEach((Entity entity, ref Rocket rocket, ref Translation Transform) =>
            {
                Transform.Value += direction * World.TinyEnvironment().frameDeltaTime * speed;



                if (Transform.Value.y >= 15)
                {
                    Transform.Value.y = -15;
                    config.launchSystem = false;
                    config.changeScreen2 = true;
                    tinyEnv.SetConfigData(config);
                }

            });
        }
    }
}

