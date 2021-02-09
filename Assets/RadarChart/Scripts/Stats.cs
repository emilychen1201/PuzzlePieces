

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public event EventHandler OnStatsChanged;

    public static int STAT_MIN = 0;
    //public static int STAT_MAX = 12;

    public enum Type {
        Attack,
        Defence,
        Speed,
    }

    private SingleStat attackStat;
    private SingleStat defenceStat;
    private SingleStat speedStat;

    public Stats(float attackStatAmount, float defenceStatAmount, float speedStatAmount) {
        attackStat = new SingleStat(attackStatAmount,60);
        defenceStat = new SingleStat(defenceStatAmount,12);
        speedStat = new SingleStat(speedStatAmount,100);
    }


    private SingleStat GetSingleStat(Type statType) {
        switch (statType) {
        default:
        case Type.Attack:       return attackStat;
        case Type.Defence:      return defenceStat;
        case Type.Speed:        return speedStat;
        }
    }
    
    public void SetStatAmount(Type statType, int statAmount) {
        GetSingleStat(statType).SetStatAmount(statAmount);
        if (OnStatsChanged != null) OnStatsChanged(this, EventArgs.Empty);
    }

    public float GetStatAmount(Type statType) {
        return GetSingleStat(statType).GetStatAmount();
    }

    public float GetStatAmountNormalized(Type statType) {
        return GetSingleStat(statType).GetStatAmountNormalized();
    }



    /*
     * Represents a Single Stat of any Type
     * */
    private class SingleStat {

        private float stat;
        
        private int stat_max;

        public SingleStat(float statAmount,int statMax) {
            SetStatMax(statMax);
            SetStatAmount(statAmount);
        }

        public void SetStatMax(int statMax){
            stat_max=statMax;
        }

        public void SetStatAmount(float statAmount) {      
           stat = Mathf.Clamp(statAmount, STAT_MIN, stat_max);
        }

        public float GetStatAmount() {
            return stat;
        }

        public int getStatMax(){
            return stat_max;
        }

        public float GetStatAmountNormalized() {
            return (float)stat / (stat_max-STAT_MIN);
          
        }
    }
}

