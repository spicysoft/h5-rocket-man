using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny.Core2D;
namespace RocketMan
{
    public struct GameConfig : IComponentData
    {
        public bool tes;
        public bool RandomSet;
        public bool WaitforSeconds;
        public bool changeScreen;
        public bool setting;
        public bool launchSystem;
        public bool changeScreen2;
        public bool judgeSystem;
        public bool retrySystem;
        public bool nextSystem;

        public int Score;
        public int BestScore;
        public int Rounds;
        public int YRandomMax;
        public int XRandomMax;
        public float distance;
        public Translation answerDirectiion;

        public Translation PlanetLocation;
    }

}

