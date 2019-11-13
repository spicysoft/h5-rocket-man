using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;
namespace RocketMan
{
    public class JudgeSystem : ComponentSystem
    {
        float speed = 5;
        float scaleSpeed = 2;
        float3 direction = new float3(0, 1, 0);
        bool correct;
        float distance =1.5f;
        int Point = 10;

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.judgeSystem)
                return;

            if(math.distance(config.answerDirectiion.Value,config.PlanetLocation.Value) < distance)
            {
                correct = true;
            }
            else
            {
                correct = false;
            }
            Entities.ForEach((Entity entity, ref Rocket rocket, ref Translation Transform, ref NonUniformScale nonUniformScale) =>
            {
                Transform.Value += direction * World.TinyEnvironment().frameDeltaTime * speed;

                if(math.distance(Transform.Value, config.answerDirectiion.Value) < 1f)
                {
                    speed = 0;
                    Transform.Value = config.answerDirectiion.Value;



                    Entities.ForEach((Entity _entity, ref Fire fire, ref Sprite2DRenderer sprite2DRenderer) =>
                    {
                        sprite2DRenderer.color.a = 0;
                    });


                    if (correct)
                    {
                        nonUniformScale.Value -= World.TinyEnvironment().frameDeltaTime * scaleSpeed;

                        if(nonUniformScale.Value.x < 0f)
                        {
                            speed = 5;
                            config.judgeSystem = false;
                            config.Score += Point; 
                            Entities.ForEach((Entity _entity, ref NextButton nextButton, ref Sprite2DRenderer sprite2DRenderer) =>
                            {
                                sprite2DRenderer.color.a = 1;
                            });

                            Entities.ForEach((Entity _entity, ref Success success, ref Sprite2DRenderer sprite2DRenderer) =>
                            {
                                sprite2DRenderer.color.a = 1;
                            });

                        }
                    }
                    else
                    {
                        speed = 5;
                        config.judgeSystem = false;
                        Entities.ForEach((Entity _entity, ref RetryButton retryButton, ref Sprite2DRenderer sprite2DRenderer) =>
                        {
                            sprite2DRenderer.color.a = 1;
                        });
                        Entities.ForEach((Entity _entity, ref GameOverTitle gameOver, ref Sprite2DRenderer sprite2DRenderer) =>
                        {
                            sprite2DRenderer.color.a = 1;
                        });
                    }

                }

            });

            tinyEnv.SetConfigData(config);
        }
    }

}


