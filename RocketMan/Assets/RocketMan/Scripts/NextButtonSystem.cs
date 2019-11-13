using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Entities;
using Unity.Tiny.UIControls;


namespace RocketMan
{
    public class NextButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var nextButton = false;

            Entities.WithAll<NextButton>().ForEach((Entity entity, ref Sprite2DRenderer sprite2DRenderer, ref PointerInteraction pointerInteraction) =>
            {
                nextButton = pointerInteraction.clicked;
                if (nextButton)
                {
                    pointerInteraction.clicked = false;
                    sprite2DRenderer.color.a = 0;
                }
            });
            if (nextButton)
            {
                config.nextSystem = true;
                nextButton = false;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}

