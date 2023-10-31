using System;
using XIV.Core.Collections;
using XIV.Stats;

namespace XIV.BoostSystem
{
    public struct MultiStatBooster
    {
        public Stat[] OriginalStats => originalStats;
        public Stat[] BoostedStats => boostedStats;
        public BoostData[] BoostDatas => boostDatas;

        DynamicArray<StatBooster> boosters;
        Stat[] originalStats;
        Stat[] boostedStats;
        BoostData[] boostDatas;
        int statLength;
        DynamicArray<int> boostedStatIndices;

        public MultiStatBooster(BoostData[] boostDatas, Stat[] statsToBoost)
        {
            statLength = statsToBoost.Length;
            this.boosters = new DynamicArray<StatBooster>(statLength);
            this.originalStats = new Stat[statLength];
            this.boostedStats = new Stat[statLength];
            this.boostDatas = boostDatas;
            this.boostedStatIndices = new DynamicArray<int>(statLength);

            Array.Copy(statsToBoost, this.originalStats, statLength);
            Array.Copy(statsToBoost, this.boostedStats, statLength);

            for (int i = 0; i < statLength; i++)
            {
                for (int j = 0; j < boostDatas.Length; j++)
                {
                    if (originalStats[i].StatType != boostDatas[j].BoostEffect.StatType) continue;

                    boosters.Add() = new StatBooster(boostDatas[j], originalStats[i]);
                    boostedStatIndices.Add() = i;
                }
            }
        }

        public void UpdateOriginals(Stat[] newOriginals)
        {
            int boosterCount = boosters.Count;
            for (int i = 0; i < statLength; i++)
            {
                var newOriginal = newOriginals[i];
                this.originalStats[i] = newOriginal;
                for (int j = 0; j < boosterCount; j++)
                {
                    if (newOriginal.StatType != boosters[j].OriginalStat.StatType) continue;

                    boosters[j].UpdateOriginal(newOriginal);
                }
            }
        }

        public void StartBoost()
        {
            for (int i = 0; i < boosters.Count; i++)
            {
                boosters[i].StartBoost();
                boostedStats[boostedStatIndices[i]] = boosters[i].BoostedStat;
            }
        }

        public bool Update(float deltaTime)
        {
            for (var i = boosters.Count - 1; i >= 0; i--)
            {
                bool isDone = boosters[i].Update(deltaTime);
                boostedStats[boostedStatIndices[i]] = boosters[i].BoostedStat;

                if (isDone == false) continue;

                boosters.RemoveAt(i);
                boostedStatIndices.RemoveAt(i);
            }

            return boosters.Count == 0;
        }
    }
}