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
                    if(set.direciton.y == 1 || set.direciton.y == -1)
                    {
                        if (config.answerDirectiion.Value.y >= -config.YRandomMax && config.answerDirectiion.Value.y <= config.YRandomMax)
                        {
                            config.answerDirectiion.Value += set.direciton * World.TinyEnvironment().frameDeltaTime * speed;

                            if (config.answerDirectiion.Value.y < -config.YRandomMax)
                            {
                                config.answerDirectiion.Value.y = -config.YRandomMax;
                            }
                            else if (config.answerDirectiion.Value.y > config.YRandomMax)
                            {
                                config.answerDirectiion.Value.y = config.YRandomMax;
                            }


                            tinyEnv.SetConfigData(config);
                        }
                    }

                    else if(set.direciton.x == 1 || set.direciton.x == -1)
                    {
                        if (config.answerDirectiion.Value.x >= -config.XRandomMax && config.answerDirectiion.Value.x <= config.XRandomMax)
                        {
                            config.answerDirectiion.Value += set.direciton * World.TinyEnvironment().frameDeltaTime * speed;

                            if (config.answerDirectiion.Value.x < -config.XRandomMax)
                            {
                                config.answerDirectiion.Value.x = -config.XRandomMax;
                            }
                            else if (config.answerDirectiion.Value.x > config.XRandomMax)
                            {
                                config.answerDirectiion.Value.x = config.XRandomMax;
                            }


                            tinyEnv.SetConfigData(config);
                        }

                    }


                }
            });

        }
    }
}


