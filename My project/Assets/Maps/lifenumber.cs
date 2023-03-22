using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lifenumber : MonoBehaviour
{
    public static int life = 5;
    public GameObject[] Life;
    public static float timerStart = 300;
    public Text timerText;
    public static int maxlife = 5;
    bool fullife;

    // Start is called before the first frame update

    void Awake()
    {           
            if (PlayerPrefs.HasKey("New player") == false)
            {
            PlayerPrefs.SetInt("New player", 1);             
            PlayerPrefs.SetInt("life", maxlife);
            PlayerPrefs.Save();
                Debug.Log("New");
            }
            else
            {
             PlayerPrefs.SetInt("life", 5);
            life = PlayerPrefs.GetInt("life");                
            PlayerPrefs.Save();
                Debug.Log("Old");
            }
          
        
    }

    // Update is called once per frame
    void Update()
    {
        life = PlayerPrefs.GetInt("life");
        if (life > maxlife)
        {
            PlayerPrefs.SetInt("life", maxlife);
        }
        if (life < 5)
        {
            fullife = false;

        }
        else
        {
            fullife = true;
        }
        if (fullife == false)
        {
            timerStart -= Time.deltaTime;

            //        int hours = Mathf.FloorToInt(InitScript.RestLifeTimer / 3600);
            //       int minutes = Mathf.FloorToInt((InitScript.RestLifeTimer - hours * 3600) / 60);
            //      int seconds = Mathf.FloorToInt((InitScript.RestLifeTimer - hours * 3600) - minutes * 60);

            if (timerStart <= 0)
            {
                Debug.Log("+1");
                life = life + 1;
                PlayerPrefs.SetInt("life", life);
                if (life < 5)
                {
                    timerStart = 300;
                    PlayerPrefs.Save();
                }
                else
                {
                    fullife = true;
                    timerStart = 300;
                    PlayerPrefs.Save();
                }
            }
        }

        if (life <= 4)
                {

                    Life[0].gameObject.SetActive(false);
                    if (life <= 3)
                    {

                        Life[1].gameObject.SetActive(false);
                        if (life <= 2)
                        {

                            Life[2].gameObject.SetActive(false);
                            if (life <= 1)
                            {

                                Life[3].gameObject.SetActive(false);
                                if (life == 0)
                                {

                                    Life[4].gameObject.SetActive(false);
                                }
                                else Life[4].gameObject.SetActive(true);
                            }
                            else Life[3].gameObject.SetActive(true);
                        }
                        else Life[2].gameObject.SetActive(true);
                    }
                    else Life[1].gameObject.SetActive(true);
                }
                else Life[0].gameObject.SetActive(true);
          

    }
   
    public static void LostLife()
    {
        life -= 1;
        PlayerPrefs.SetInt("life", life);
        Debug.Log("-1");
        PlayerPrefs.Save();
    }
    private void AddLife()
    {
       
        
        
    }
}