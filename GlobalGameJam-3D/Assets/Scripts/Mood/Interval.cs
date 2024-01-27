using System;
using UnityEngine;

namespace GlobalGameJam
{
    [Serializable]
    public struct Interval
    {
        [Range(0f, 1f)] public float MinValue;
        [Range(0f, 1f)] public float MaxValue;
    }
}