using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class TestScript : MonoBehaviour
{
    TimeSpan ts;
    private GameObject Cloud;
    public static string lifetimeadd;
    public static float lifttime;
    public Transform[] waypoints;
    private void Awake()
    {
       // PlayerPrefs.SetInt("CloudProgress", 0);
        Cloud = GameObject.Find("Cloud"); 
        CheckOffline();
        CheckGameProgress();
        
    }
    private void Update()
    {
        for (int i = 0; i <= 21; ++i) 
        {
            if (PlayerPrefs.GetInt("LvlProgress") >= i) 
            { 
             
            }
        }


    }
    private void CheckOffline()
    {
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            print(string.Format("Время отсутсвия: {0} дней, {1} часов, {2} минут, {3} секунд", ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
          //  print(string.Format("Время отсутсвия: {0} времени", ts.TotalSeconds));
        }
        if (PlayerPrefs.GetInt("life") < 5 && ts.TotalSeconds >= 300)
        {         
            lifetimeadd = string.Format("{0}", ts.TotalSeconds);
            PlayerPrefs.SetInt("life", (int)(PlayerPrefs.GetInt("life") + (float.Parse(lifetimeadd) / 300)));
            if ((lifenumber.timerStart < (float.Parse(lifetimeadd) % 300)) && PlayerPrefs.GetInt("life") < 5)
            {
                lifttime = (float.Parse(lifetimeadd) % 300) - lifenumber.timerStart;
                PlayerPrefs.SetInt("life", +1);
                lifenumber.timerStart = 300;
                lifenumber.timerStart = lifenumber.timerStart - lifttime;
                PlayerPrefs.Save();
            }
            else
            {
                
                lifenumber.timerStart = lifenumber.timerStart - (float.Parse(lifetimeadd) % 300);
                PlayerPrefs.Save();
                

            }
        }
        else
        {
            lifenumber.timerStart = 300;
            PlayerPrefs.Save();
        }
    }
    private void OnApplicationPause(bool pause) 
    {
        if (pause)
        {    
            PlayerPrefs.SetInt("Lifes", lifenumber.life);
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
            PlayerPrefs.Save();
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Lifes", lifenumber.life);
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        PlayerPrefs.Save();
    }
    private void CheckGameProgress()
    {        
        for (int i = 0; i <= 21; ++i)
        {
            if (PlayerPrefs.GetInt("CloudProgress") >= i)
            {              
                Destroy(Cloud.transform.GetChild(i).gameObject);
            }

        }
 
    }
}
