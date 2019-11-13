using Unity.Entities;
using Unity.Tiny.Text;
using Unity.Tiny.Core;

namespace RocketMan
{
    public class ScoreSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();


            if(config.Score >= config.BestScore){
                config.BestScore = config.Score;
            }

            Entities.WithAll<ScoreText>().ForEach((Entity entity) =>
            {
                EntityManager.SetBufferFromString<TextString>(entity, "Score:" + config.Score.ToString());
                tinyEnv.SetConfigData(config);

            });
            Entities.WithAll<BestScoreText>().ForEach((Entity entity) =>
            {
                EntityManager.SetBufferFromString<TextString>(entity, "BestScore:" + config.BestScore.ToString());
                tinyEnv.SetConfigData(config);

            });
            tinyEnv.SetConfigData(config);
        }
    }
}

