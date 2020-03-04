using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //public Transform[] spawnPoints;
    public Transform spawnPoint_A;
    public Transform spawnPoint_B;
    public Transform spawnPoint_C;
    public Transform spawnPoint_D;

    public bool isGameMenu = false;
    public bool toggleMenu = false;

    public GameObject player;

    public static LevelManager instance;

    public GameObject menu_A;
    public GameObject menu_B;
    public int watergunInt = 0;
    public int hatInt = 0;
    public int pinguInt = 0;

    public GameObject[] hats;
    public GameObject[] guns;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void toggleMenuOn()
    {
        toggleMenu =!toggleMenu;
    }

    public void waterGunPlus()
    {
        watergunInt++;
        if (watergunInt > 2)
        { watergunInt = 0; }

        switchGun();
    }
    public void waterGunMinus()
    {
        watergunInt--;
        if (watergunInt < 0)
        { watergunInt = 2; } 

        switchGun();
    }
    public void hatPlus()
    {
        hatInt ++;
        switchHat();
    }
    public void hatMinus()
    {
        hatInt--;
        switchHat();
    }
    public void pinguPlus()
    {
        pinguInt++;
    }
    public void PinguMinus()
    {
        pinguInt--;
    }

    //*********************************************************************************************************************************************

    //switch out items on button press



    public void switchGun()
    {
        //not more hats than there are!


        switch (watergunInt)
        {
            case 0:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[0].SetActive(true);
                break;
            case 1:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[1].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[2].SetActive(true);
                break;

            default:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[1].SetActive(true);

                break;
        }
    }



    public void switchHat()
    {
        //not more hats than there are!
        if (hatInt < 0) { hatInt = hats.Length; } else if (hatInt > hats.Length) { hatInt = 0; }


        switch (hatInt)
        {
            case 0:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[0].SetActive(true);
                break;
            case 1:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[1].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[2].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[3].SetActive(true);
                break;
            case 4:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[4].SetActive(true);
                break;
            case 5:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[5].SetActive(true);
                break;
            case 6:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[6].SetActive(true);
                break;
            case 7:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[7].SetActive(true);
                break;
            case 8:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[8].SetActive(true);
                break;
            default:
                break;
        }
    }


    //********************************************************************************************************************************************

    public void loadMultiPlayer()
    {

        //All levels will be the same level - we simply instantiate another
        //Level prefab before the start of the game - this will be done
        //with playerprefs get (ingame) and set (menu)

        //set playerprefs for player 1
        PlayerPrefs.SetInt("HatInt", hatInt);
        PlayerPrefs.SetInt("GunInt", watergunInt);
        PlayerPrefs.SetInt("PenguinInt", pinguInt);
        //when the player loads in the game scene, we load the prefabs by first getting
        //the playerpref ints and thus equipping the player with the items!



        Application.LoadLevel("GameScene");

    }

    public void loadTestLevel()
    {
        PlayerPrefs.SetInt("HatInt", hatInt);
        PlayerPrefs.SetInt("GunInt", watergunInt);
        PlayerPrefs.SetInt("PenguinInt", hatInt);

        Application.LoadLevel("GameScene");

    }


    public void respawn(GameObject player)
    {
        int mySpawnPosition = Random.Range(0, 3);
        player.transform.rotation = Quaternion.identity;

        if (mySpawnPosition == 0)
        {
            player.transform.position =spawnPoint_A.position;
        }
        else if (mySpawnPosition == 1)
        {
            player.transform.position = spawnPoint_B.position;
        }
        else if (mySpawnPosition == 2)
        {
            player.transform.position = spawnPoint_C.position;
        }
        if (mySpawnPosition == 3)
        {
            player.transform.position = spawnPoint_D.position;
        }
    }

    


    // Update is called once per frame
    void Update()
    {

        //is this the game or the menu?
        if (isGameMenu == true)
        {
            //if we press a button we show character creation
            //menu and the map selection (for some modi)
            if (toggleMenu == true)
            {
                menu_B.SetActive(true);
                menu_A.SetActive(false);

               

                //here in character selection we determine which hat you show on the player
                //by pressing a button.. So use the switch case to switch out hats, weapons etc..

            }
            else
            {
                menu_B.SetActive(false);
                menu_A.SetActive(true);
            }

        }
    }
}
