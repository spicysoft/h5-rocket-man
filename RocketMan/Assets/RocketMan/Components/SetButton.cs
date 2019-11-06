using Unity.Entities;
using Unity.Tiny.Core2D;
using Unity.Mathematics;

namespace RocketMan
{
    public struct SetButton : IComponentData
    {
        public int3 direciton;
    }
}


