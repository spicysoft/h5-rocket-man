using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;
using Unity.Mathematics;

namespace RocketMan
{
    public class SetButtonSystem : ComponentSystem
    {
        float speed = 10;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();

            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var setButton = false;
            
            Entities.WithAll<SetButton>().ForEach((Entity entity, ref Sprite2DRenderer sprite2DRenderer, ref PointerInteraction pointerInteraction,ref SetButton set) =>
            {
                setButton = pointerInteraction.down;
                if (setButton)
                {
                    config.answerDirectiion.Value += set.direciton * World.TinyEnvironment().frameDeltaTime * speed;
                    tinyEnv.SetConfigData(config);
                }

            });


            //if (setButton)
            //{
            //    //setButton = false;
            //    //tinyEnv.SetConfigData(config);
            //}
        }
    }
}


