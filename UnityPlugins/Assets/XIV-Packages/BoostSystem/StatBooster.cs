using UnityEngine;
using XIV.Core.Utils;
using XIV.Stats;

namespace XIV.BoostSystem
{
    public struct StatBooster
    {
        public Stat OriginalStat => originalStat;
        public Stat BoostedStat => boostedStat;
        
        BoostData boostData;
        Stat originalStat;
        Stat boostedStat;
        Timer timer;

        public StatBooster(BoostData boostData, Stat statToBoost)
        {
            this.boostData = boostData;
            this.originalStat = statToBoost;
            this.boostedStat = statToBoost;
            this.timer = new Timer(boostData.Duration);
        }

        public void UpdateOriginal(Stat newOriginal)
        {
            this.originalStat = newOriginal;
            StartBoost();
            Update(0);
        }
        
        public void StartBoost()
        {
            Update(0);
        }

        public bool Update(float deltaTime)
        {
            bool isDone = timer.Update(deltaTime);
            var boostWeightAtTime = boostData.Curve.Evaluate(timer.NormalizedTime);
            UpdateBoostData(boostWeightAtTime);
            
            if (isDone) boostedStat = originalStat;
            return isDone;
        }

        void UpdateBoostData(float normalizedTime)
        {
            var boostedTotal = Boost(originalStat.Total, boostData.BoostEffect.Total, normalizedTime);
            boostedStat.SetTotal(boostedTotal);
            
            var boostedCurrent = Boost(originalStat.Current, boostData.BoostEffect.Current, normalizedTime);
            boostedStat.SetCurrent(boostedCurrent);
        }

        float Boost(float original, float boost, float normalizedTime)
        {
            var afterBoost = original + boost;
            var boosted = Mathf.LerpUnclamped(original, afterBoost, normalizedTime);
            return boosted;
        }
    }
}