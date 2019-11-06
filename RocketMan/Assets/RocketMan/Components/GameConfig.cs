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

        public int3 answerDirectiion;

        public Translation PlanetLocation;
    }

}

