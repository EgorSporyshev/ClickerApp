using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using YG;

public class MainMenu : MonoBehaviour
{
    //private static Timer timer;
    [SerializeField] int money; //переменная количества игровой валюты

    public GameObject panel;
    public GameObject Progress; 
    public GameObject Shop;
    public GameObject GameOver;
    public GameObject moneyPad;

    public AudioSource myFX;
    public AudioClip clickFX;
    public AudioClip clickFX2;

    public GameObject ach1;
    public GameObject ach2;
    public GameObject ach3;
    public GameObject ach_mark;
    public GameObject ach_new;

    public GameObject Cheat;
    public GameObject CheatReset;

    public Sprite sprite_0;
    public Sprite sprite_1;
    public Sprite sprite_2;
    public Sprite sprite_3;
    public Sprite sprite_4;

    public Text moneyText;
    public Text ShopMoneyText;

    public TextMeshProUGUI UpText1;
    public TextMeshProUGUI UpText2;
    public TextMeshProUGUI UpText3;

    public static event Action New_Achievement;
    public static event Action Cheat_1;
    public static event Action Achievement_1;
    public static event Action Achievement_2;
    public static event Action Achievement_3;
    public static event Action Max_Score;

    //Timer timer = new Timer(2000);

    //private int TimesClicked = 0;

    public void ButtonClick()
    {
        if(Variables.money < Variables.MAX_MONEY)
        {
            if(Variables.money + Variables.click_value > Variables.MAX_MONEY)
            {
                Variables.money = Variables.MAX_MONEY;
            }
            else
            {
                Variables.money += Variables.click_value; 
            }      
        }        
        Variables.TimesClicked++;
        Save();
    }

    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }

    public void ShopPanel()
    {
        Progress.SetActive(false);
        Shop.SetActive(!Shop.activeInHierarchy);
        if(Shop.activeInHierarchy) { moneyPad.SetActive(false); } else { moneyPad.SetActive(true); }
        Debug.Log(Shop.activeInHierarchy);
    }

    public void ProgressPanel()
    {
        Shop.SetActive(false);
        ach_mark.SetActive(false);
        ach_new.SetActive(false);
        Progress.SetActive(!Progress.activeInHierarchy);
        moneyPad.SetActive(true); 

        Debug.Log(Progress.activeInHierarchy);
    }

    void Achievement_Mark()
    {
        ach_mark.SetActive(true);
        ach_new.SetActive(true);
        myFX.PlayOneShot(clickFX2);
        Invoke("Achievement_Close", 3);
    }

    void Achievement_Close()
    {
        ach_new.SetActive(false);
    }


    void Cheat_Change()
    {
        panel.GetComponent<Image>().sprite = sprite_3;
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
        New_Achievement += Achievement_Mark;
        Max_Score += Game_Over;
        Cheat_1 += Cheat_Change;
    }
    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetData;
        New_Achievement -= Achievement_Mark;
        Max_Score -= Game_Over;
    }

    void Game_Over()
    {
        GameOver.SetActive(true);
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetData();
        }     
        
        money = Variables.money;
        Shop.SetActive(false);
        Progress.SetActive(false);
        ach_mark.SetActive(false);
        ach_new.SetActive(false);
        GameOver.SetActive(false);


        //timer.Elapsed += AutoSave;
        //timer.AutoReset = true;
        //timer.Enabled = true;
    }


    private void Save()
    {
        YandexGame.savesData.money = Variables.money;
        YandexGame.savesData.click_value = Variables.click_value;
        YandexGame.savesData.TimesClicked = Variables.TimesClicked;
        YandexGame.savesData.upgrade_1 = Variables.upgrade_1;
        YandexGame.savesData.upgrade_2 = Variables.upgrade_2;
        YandexGame.savesData.upgrade_3 = Variables.upgrade_3;
        YandexGame.savesData.achievement_1 = Variables.achievement_1;
        YandexGame.savesData.achievement_2 = Variables.achievement_2;
        YandexGame.savesData.achievement_3 = Variables.achievement_3;

        YandexGame.SaveProgress();
    }

    private void AutoSave(object sender, ElapsedEventArgs e)
    {
        Variables.Save();
        
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        //Variables.money = money;
        moneyText.text = Variables.money.ToString();
        //ShopMoneyText.text = Variables.money.ToString();
        //

        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyUp(KeyCode.P))
        {
            if(!Cheat.activeSelf && !CheatReset.activeSelf)
            {
                Cheat.SetActive(true);
                CheatReset.SetActive(true);
            } else if (Cheat.activeSelf && CheatReset.activeSelf)
            {
                Cheat.SetActive(false);
                CheatReset.SetActive(false);
            }
        }

        if (Variables.cheat)
        {
            Cheat_1?.Invoke();
        }

        if (Variables.TimesClicked >= Variables.Achievement_1 && !Variables.achievement_1)
        {
            New_Achievement?.Invoke();
            Achievement_1?.Invoke();
            Variables.achievement_1 = true;
        }        

        if (Variables.UpgradeCount() == 3 && !Variables.achievement_2)
        {
            New_Achievement?.Invoke();
            Achievement_2?.Invoke();
            Variables.achievement_2 = true;
        }        

        if (Variables.money >= Variables.Achievement_3 && !Variables.achievement_3 )
        {
            New_Achievement?.Invoke();
            Achievement_3?.Invoke();
            Variables.achievement_3 = true;
        }     

        if(Variables.achievement_1 && Variables.achievement_2 && Variables.achievement_3 && Variables.money == Variables.MAX_MONEY)
        {
            Max_Score?.Invoke();
        }
    }

    private void OnApplicationQuit()
    {
        //timer.Dispose();
    }

    public void GetData()
    {
        // Получаем данные из плагина и делаем с ними что хотим
        Variables.money = YandexGame.savesData.money;
        Variables.click_value = YandexGame.savesData.click_value;
        Variables.TimesClicked = YandexGame.savesData.TimesClicked;

        Variables.upgrade_1 = YandexGame.savesData.upgrade_1;
        Variables.upgrade_2 = YandexGame.savesData.upgrade_2;
        Variables.upgrade_3 = YandexGame.savesData.upgrade_3;
        Variables.achievement_1 = YandexGame.savesData.achievement_1;
        Variables.achievement_2 = YandexGame.savesData.achievement_2;
        Variables.achievement_3 = YandexGame.savesData.achievement_3;

        UpdatePanel();
    }

    private void UpdatePanel()
    {
        if (Variables.upgrade_1 && !Variables.upgrade_2 && !Variables.upgrade_3)
        {
            panel.GetComponent<Image>().sprite = sprite_1;
        }
        if (Variables.upgrade_1 && Variables.upgrade_2 && !Variables.upgrade_3)
        {
            panel.GetComponent<Image>().sprite = sprite_2;
        }
        if (Variables.upgrade_1 && Variables.upgrade_2 && Variables.upgrade_3)
        {
            panel.GetComponent<Image>().sprite = sprite_3;
        }
        //throw new NotImplementedException();
    }

    public void ResetSave()
    {
        Variables.ResetSave();
        panel.GetComponent<Image>().sprite = sprite_0;
        ach1.GetComponent<Image>().sprite = sprite_4;
        ach2.GetComponent<Image>().sprite = sprite_4;
        ach3.GetComponent<Image>().sprite = sprite_4;
        GameOver.SetActive(false);
        ShopList.Change_Text_Reset(UpText1, Variables.price_1.ToString());
        ShopList.Change_Text_Reset(UpText2, Variables.price_2.ToString());
        ShopList.Change_Text_Reset(UpText3, Variables.price_3.ToString());
    }


}
