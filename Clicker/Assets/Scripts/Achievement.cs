using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public GameObject Ach1;
    public GameObject Ach2;
    public GameObject Ach3;

    public TextMeshProUGUI a1;
    public TextMeshProUGUI a2;
    public TextMeshProUGUI a3;   
    
    public Sprite sprite_new;
    public Sprite sprite_old;

    public void Achievement1()
    {
        if (!Variables.achievement_1)
        {
            Variables.achievement_1 = true;
            Variables.Save();
            //New_Achievement?.Invoke();
        }        
        Ach1.GetComponent<Image>().sprite = sprite_new;
        //Debug.Log("ddd");
        a1.text = "Нажать на кнопку " + Variables.Achievement_1 + " раз\n" + Variables.Achievement_1 + "/" + Variables.Achievement_1 + "\n\n" + "Выполнено";

        
    }

    public void Achievement2()
    {
        if (!Variables.achievement_2)
        {
            Variables.achievement_2 = true;
            Variables.Save();
        }

        //Variables.achievement_2 = true;
        Ach2.GetComponent<Image>().sprite = sprite_new;
        //Debug.Log("ddd");
        a2.text = "Купить все улучшения\n" + Variables.UpgradeCount() + "/3\n\n" + "Выполнено";
        
        //Variables.Save();
    }

    public void Achievement3()
    {
        if (!Variables.achievement_3)
        {
            Variables.achievement_3 = true;
            Variables.Save();
        }
        //Variables.achievement_3 = true;
        Ach3.GetComponent<Image>().sprite = sprite_new;
        //Debug.Log("ddd3");
        a3.text = "Довести счет до\n" + Variables.Achievement_3 + "\n" + Variables.Achievement_3 +"/" + Variables.Achievement_3+"\n" + "Выполнено";
        
        //Variables.Save();
    }

    private void OnEnable()
    {
        MainMenu.Achievement_1 += Achievement1;
        MainMenu.Achievement_2 += Achievement2;
        MainMenu.Achievement_3 += Achievement3;
    }

    private void OnDisable()
    {
        MainMenu.Achievement_1 -= Achievement1;
        MainMenu.Achievement_2 -= Achievement2;
        MainMenu.Achievement_3 -= Achievement3;
    }

    // Start is called before the first frame update Наберите 150 валюты
    void Start()
    {
        if (Variables.achievement_1)
        {
            Achievement1();
        }
        else
        {
            Ach1.GetComponent<Image>().sprite = sprite_old;
            a1.text = "Наберите " + Variables.Achievement_1 + " валюты\n"+ Variables.TimesClicked+"/"+Variables.Achievement_1 +"\n\n"+"Не выполнено" ;            
        }

        if (Variables.achievement_2)
        {
            Achievement2();
        }
        else
        {
            Ach2.GetComponent<Image>().sprite = sprite_old;
            a2.text = "Купить все улучшения\n" + Variables.UpgradeCount() +"/3\n\n"+ "Не выполнено";
        }
        if (Variables.achievement_3)
        {
             Achievement3();
        } else 
        {
            Ach3.GetComponent<Image>().sprite = sprite_old;
            a3.text = "Довести счет до " + Variables.Achievement_3 + "\n\n" + Variables.money + "/" + Variables.Achievement_3 + "\n" + "Не выполнено";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.TimesClicked >= Variables.Achievement_1 && !Variables.achievement_1 || Variables.achievement_1) {
            Achievement1();
        }else if(!Variables.achievement_1) {
            Ach1.GetComponent<Image>().sprite = sprite_old;
            a1.text = "Наберите " + Variables.Achievement_1 + " валюты\n" + Variables.TimesClicked + "/" + Variables.Achievement_1 + "\n\n" + "Не выполнено";
        } 

        if(Variables.UpgradeCount() == 3 && !Variables.achievement_2 || Variables.achievement_2)
        {
            Achievement2();
        } else if(!Variables.achievement_2){
            Ach2.GetComponent<Image>().sprite = sprite_old;
            a2.text = "Купить все улучшения\n" + Variables.UpgradeCount() + "/3\n\n" + "Не выполнено";
        }

        if(Variables.money >= Variables.Achievement_3 && !Variables.achievement_3 || Variables.achievement_3) {
            Achievement3();
        } else if(!Variables.achievement_3) {
            Ach3.GetComponent<Image>().sprite = sprite_old;
            a3.text = "Довести счет до " + Variables.Achievement_3 + "\n\n" + Variables.money + "/" + Variables.Achievement_3 + "\n" + "Не выполнено"; 
        }
    }
}
