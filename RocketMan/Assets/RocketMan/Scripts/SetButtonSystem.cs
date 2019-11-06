using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace RocketMan
{
    public class SetButtonSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var setButton = false;

            Entities.WithAll<SetButton>().ForEach((Entity entity, ref Sprite2DRenderer sprite2DRenderer, ref PointerInteraction pointerInteraction,ref SetButton set) =>
            {
                setButton = pointerInteraction.clicked;
                if (setButton)
                {
                    config.answerDirectiion += set.direciton;
                    pointerInteraction.clicked = false;
                }

            });


            if (setButton)
            {
                setButton = false;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}


