using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;


namespace RocketMan
{
    public class RetryButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();

            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var retryButton = false;

            Entities.WithAll<RetryButton>().ForEach((Entity entity, ref Sprite2DRenderer sprite2DRenderer, ref PointerInteraction pointerInteraction) =>
            {
                retryButton = pointerInteraction.clicked;
                if (retryButton)
                {
                    retryButton = false;
                    pointerInteraction.clicked = false;
                    sprite2DRenderer.color.a = 0;
                    config.retrySystem = true;
                    tinyEnv.SetConfigData(config);

                }

            });

        }
    }
}

