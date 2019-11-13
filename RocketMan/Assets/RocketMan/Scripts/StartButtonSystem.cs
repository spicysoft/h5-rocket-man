using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Entities;
using Unity.Tiny.UIControls;

namespace RocketMan
{
    public class StartButtonSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var startButton = false;
            
            Entities.WithAll<StartButton>().ForEach((Entity entity,ref Sprite2DRenderer sprite2DRenderer,ref PointerInteraction pointerInteraction) =>
            {
                startButton = pointerInteraction.clicked;
                if (startButton)
                {
                    pointerInteraction.clicked = false;
                    sprite2DRenderer.color.a = 0;
                }

            });


            if (startButton)
            {

                Entities.ForEach((Entity entity, ref Title title, ref Translation Transform, ref Sprite2DRenderer sprite2DRenderer) =>
                {
                    sprite2DRenderer.color.a = 0;

                });


                config.RandomSet = true;
                startButton = false;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}

