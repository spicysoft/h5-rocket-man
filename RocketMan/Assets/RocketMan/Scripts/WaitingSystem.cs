using Unity.Entities;
using Unity.Tiny.Core;

namespace RocketMan
{
    public class WaitingSystem : ComponentSystem
    {

        float Time = 2;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.WaitforSeconds)
                return;

            Time -= World.TinyEnvironment().frameDeltaTime;

            if (Time < 0)
            {
                config.WaitforSeconds = false;
                config.changeScreen = true;
                Time = 2;
            }
            tinyEnv.SetConfigData(config);
        }
    }
}

