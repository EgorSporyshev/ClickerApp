using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{   
    public GameObject Main;
    public GameObject Shop;
    public GameObject Warning;

    public AudioSource myFX;
    public AudioClip clickFX;
    public AudioClip clickFX2;

    public Sprite sprite_1;
    public Sprite sprite_2;
    public Sprite sprite_3;

    public Sprite sprite_dissabled;
    public Sprite sprite_bought;
    public Sprite sprite_can_buy;

    public Button up1;
    public Button up2;
    public Button up3;

    public TextMeshProUGUI UpText1;
    public TextMeshProUGUI UpText2;
    public TextMeshProUGUI UpText3;
    //TextMeshPro
    public Text ShopMoneyText;


    public static void Change_Text(TextMeshProUGUI text)
    {
        string t = text.text;
        t = t.Substring(0, t.IndexOf("Цена"));
        t += "Куплено";
        text.text = t;        
    }    
    
    public static void Change_Text_Reset(TextMeshProUGUI text, string price)
    {
        string t = text.text;
        if (t.IndexOf("Куплено") > 0)
        {
            t = t.Substring(0, t.IndexOf("Куплено"));
            t += "Цена: " + price;
            text.text = t; 
        }                       
    }

    public void Upgrade1()
    {   
        if (Variables.money < Variables.price_1 && !Variables.upgrade_1)
        {
            Warning.SetActive(true);
            myFX.PlayOneShot(clickFX);
        } else if (!Variables.upgrade_1) {       
            
            BuyUpgrade(Variables.price_1);

            //string t = UpText1.text;
            //t = t.Substring(0, t.IndexOf("Цена"));
            //t += "Куплено";
            //UpText1.text = t;
            Change_Text(UpText1);

            Variables.upgrade_1 = true;          
            Main.GetComponent<Image>().sprite = sprite_1;

            Variables.Save();
            myFX.PlayOneShot(clickFX2);
        }       
        
    }

    public void Upgrade2()
    {
        if (Variables.money < Variables.price_2 && !Variables.upgrade_2)
        {
            Warning.SetActive(true);
            myFX.PlayOneShot(clickFX);
        } else if (Variables.upgrade_1 && !Variables.upgrade_2) {

            BuyUpgrade(Variables.price_2);

            //string t = UpText2.text;
            //t = t.Substring(0, t.IndexOf("Цена"));
            //t += "Куплено";
            //UpText2.text = t;
            Change_Text(UpText2);

            Variables.upgrade_2 = true;

            Main.GetComponent<Image>().sprite = sprite_2;

            Variables.Save();
            myFX.PlayOneShot(clickFX2);
        }
    }
  

    public void Upgrade3()
    {        
        if (Variables.money < Variables.price_3 && !Variables.upgrade_3)
        {
            Warning.SetActive(true);
            myFX.PlayOneShot(clickFX);
        } else if (Variables.upgrade_1 && Variables.upgrade_2 && !Variables.upgrade_3){
            BuyUpgrade(Variables.price_3);

            //string t = UpText3.text;
            //t = t.Substring(0, t.IndexOf("Цена"));
            //t += "Куплено";
            //UpText3.text = t;
            Change_Text(UpText3);

            Variables.upgrade_3 = true;
            Main.GetComponent<Image>().sprite = sprite_3;
        
            Variables.Save();
            myFX.PlayOneShot(clickFX2);
        }
    }

    void BuyUpgrade(int price)
    {
        if(Variables.money >= price)
        {
            Variables.click_value++;
            Variables.money -= price;
            UnityEngine.Debug.Log(Variables.money);
            ShopMoneyText.text = Variables.money.ToString();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
         UpText1.text += Variables.price_1.ToString();
         UpText2.text += Variables.price_2.ToString();
         UpText3.text += Variables.price_3.ToString();
    }

    // Update is called once per frame
    void Update()
    {       
        ShopMoneyText.text = Variables.money.ToString();
        //up1.interactable = (Variables.money >= Variables.price_1 && !Variables.upgrade_1 && !Variables.upgrade_2 && !Variables.upgrade_3);
        //up2.interactable = (Variables.money >= Variables.price_2 && !Variables.upgrade_2 && Variables.upgrade_1 && !Variables.upgrade_3);
        //up3.interactable = (Variables.money >= Variables.price_3 && !Variables.upgrade_3 && Variables.upgrade_1 && Variables.upgrade_2);

        if (!Variables.upgrade_1 && Variables.money >= Variables.price_1) { up1.GetComponent<Image>().sprite = sprite_can_buy; }
        if (!Variables.upgrade_2 && Variables.upgrade_1 && Variables.money >= Variables.price_2) { up2.GetComponent<Image>().sprite = sprite_can_buy; }
        if (!Variables.upgrade_3 && Variables.upgrade_2 && Variables.upgrade_1 && Variables.money >= Variables.price_3) { up3.GetComponent<Image>().sprite = sprite_can_buy; }

        if (Input.GetMouseButtonDown(0)) { Warning.SetActive(false); }

        if (Variables.upgrade_1) { up1.GetComponent<Image>().sprite = sprite_bought; }
        if (Variables.upgrade_2) { up2.GetComponent<Image>().sprite = sprite_bought; }
        if (Variables.upgrade_3) { up3.GetComponent<Image>().sprite = sprite_bought; }

        if (!Variables.upgrade_1 && Variables.money < Variables.price_1) { up1.GetComponent<Image>().sprite = sprite_dissabled; }
        if (!Variables.upgrade_2 && Variables.money < Variables.price_2) { up2.GetComponent<Image>().sprite = sprite_dissabled; }
        if (!Variables.upgrade_3 && Variables.money < Variables.price_3) { up3.GetComponent<Image>().sprite = sprite_dissabled; }
    }
}
