using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace RocketMan
{
    public class LaunchButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();

            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var launchButton = false;

            Entities.WithAll<LaunchButton>().ForEach((Entity entity, ref Sprite2DRenderer sprite2DRenderer, ref PointerInteraction pointerInteraction) =>
            {
                launchButton = pointerInteraction.clicked;
                if (launchButton)
                {

                    config.launchSystem = true;
                    tinyEnv.SetConfigData(config);
                }

            });

        }
    }
}

