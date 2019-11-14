using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;


namespace RocketMan
{
    public class RocketSettingSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();


            if (!config.setting)
                return;
            Entities.ForEach((Entity entity, ref Rocket rocket, ref Translation Transform) =>
            {
               Transform.Value.x = config.answerDirectiion.Value.x ;
            });

            Entities.ForEach((Entity entity, ref PowerBase powerBase, ref Translation Transform) =>
            {
                Transform.Value.x = config.answerDirectiion.Value.x;
            });

            Entities.ForEach((Entity entity, ref PowerGage powerGage, ref Translation Transform) =>
            {
                Transform.Value.x = config.answerDirectiion.Value.x;
                Transform.Value.y = config.answerDirectiion.Value.y;
            });
        }
    }
}

