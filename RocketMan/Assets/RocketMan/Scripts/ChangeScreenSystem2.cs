using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;


namespace RocketMan
{
    public class ChangeScreenSystem2 : ComponentSystem
    {

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.changeScreen2)
                return;
            config.changeScreen2 = false;
            Entities.ForEach((Entity entity, ref Planet planet, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 1;
            });
            Entities.ForEach((Entity entity, ref Ground ground, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref Mountain mountain, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref SetButton setButton, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref LaunchButton launchButton, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref PowerGage powerGage, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref PowerBase powerBase, ref Sprite2DRenderer sprite2DRenderer) =>
            {
                sprite2DRenderer.color.a = 0;
            });
            Entities.ForEach((Entity entity, ref Star star, ref Sprite2DRenderer sprite2DRenderer, ref Translation Transform) =>
            {
                sprite2DRenderer.color.a = 1;
            });
            Entities.ForEach((Entity entity, ref Camera2D camera) =>
            {
                camera.backgroundColor = new Color(0.1333333f, 0.1411765f, 0.1607843f);
            });
            config.judgeSystem = true;
            tinyEnv.SetConfigData(config);


        }
    }

}

