using UnityEngine;
using XIV.Stats;

namespace XIV.BoostSystem
{
    [System.Serializable]
    public struct BoostData
    {
        public Stat BoostEffect;
        public AnimationCurve Curve;
        public float Duration;
    }
}