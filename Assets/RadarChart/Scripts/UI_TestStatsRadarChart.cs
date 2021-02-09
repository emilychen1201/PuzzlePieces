

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_TestStatsRadarChart : MonoBehaviour {

    [SerializeField] private Material radarMaterial;
    private Color baseMaterialColor;
    private Stats stats;

    public void SetStats(Stats stats) {
        this.stats = stats;

        stats.OnStatsChanged += Stats_OnStatsChanged;
        UpdateStatsText();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e) {
        UpdateStatsText();
    }

    private void UpdateStatsText() {
        transform.Find("text").GetComponent<Text>().text =
            "TIEMPO PROMEDIO: " + stats.GetStatAmount(Stats.Type.Attack) + "\n" +
            "NIVEL MÁS ALTO: " + stats.GetStatAmount(Stats.Type.Defence) + "\n" +
            "TASA GANADORA: " + stats.GetStatAmount(Stats.Type.Speed) + "%\n" ;
    }

}
