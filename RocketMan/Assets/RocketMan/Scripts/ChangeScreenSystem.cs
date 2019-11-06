using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;

namespace RocketMan
{
    public class ChangeScreenSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.changeScreen)
                return;

            Entities.ForEach((Entity entity, ref Planet planet, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref Ground ground, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 1;
            });

            Entities.ForEach((Entity entity, ref SetButton setButton, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 1;
            });

            Entities.ForEach((Entity entity, ref Rocket rocket, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                Transform.Value.y = -20;
                Transform.Value.x = 0;
                sprite2DRenderer.color.a = 1;
            });





            Entities.ForEach((Entity entity, ref Camera2D camera ) =>
            {
                camera.backgroundColor = new Color(0.2559185f, 0.6196426f, 0.764151f);
            });

            tinyEnv.SetConfigData(config);
        }
    }
}


