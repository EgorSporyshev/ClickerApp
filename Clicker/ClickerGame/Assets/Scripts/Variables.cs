using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

using YG;

public class Variables : MonoBehaviour
{
    public static readonly int MAX_MONEY = 99999;
    public static int money = 0;
    public static int TimesClicked = 0;

    public static int price_1 = 100;
    public static int price_2 = 300;
    public static int price_3 = 800;

    public static int Achievement_1 = 150;
    public static int Achievement_3 = 500;

    public static int click_value = 1;

    public static bool upgrade_1 = false;
    public static bool upgrade_2 = false;
    public static bool upgrade_3 = false;

    public static bool achievement_1 = false;
    public static bool achievement_2 = false;
    public static bool achievement_3 = false;

    public static bool cheat = false;

    public static int UpgradeCount()
    { 
        int count = 0;

        if (upgrade_1) { count++; }
        if (upgrade_2) { count++; }
        if (upgrade_3) { count++; }

        return count;        
    }

    public static void Cheat() {
        money = 99990;
        click_value = 4;
        TimesClicked = 5000;
        upgrade_1 = true;
        upgrade_2 = true;
        upgrade_3 = true;

        achievement_1 = true;
        achievement_2 = true;
        achievement_3 = true;

        cheat = true;
    }

    public static void Save()
    {
        YandexGame.savesData.money = money;
        YandexGame.savesData.click_value = click_value;
        YandexGame.savesData.TimesClicked = TimesClicked;
        YandexGame.savesData.upgrade_1 = upgrade_1;
        YandexGame.savesData.upgrade_2 = upgrade_2;
        YandexGame.savesData.upgrade_3 = upgrade_3;
        YandexGame.savesData.achievement_1 = achievement_1;
        YandexGame.savesData.achievement_2 = achievement_2;
        YandexGame.savesData.achievement_3 = achievement_3;

        YandexGame.SaveProgress();
    }

    public static void ResetSave()
    {
        money = 0;
        click_value = 1;
        TimesClicked = 0;

        upgrade_1 = false;
        upgrade_2 = false; 
        upgrade_3 = false;

        achievement_1 = false;
        achievement_2 = false;
        achievement_3 = false;

        cheat = false;
        Save();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

