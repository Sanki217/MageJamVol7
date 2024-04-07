using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public List<GameObject> TurnOnAtSingleplayer;
    public List<GameObject> TurnOffAtSingleplayer;

    public List<GameObject> TurnOnAtMultiplayer;
    public List<GameObject> TurnOffAtMultiplayer;
    void Start()
    {
        //PlayerPrefs.SetInt("PlayerNumber", 2);//wy³¹czyæ
        Debug.Log("player number:" + PlayerPrefs.GetInt("PlayerNumber"));
        if (PlayerPrefs.GetInt("PlayerNumber") == 1)
        {
            foreach(GameObject t in TurnOnAtSingleplayer)
            {
                t.SetActive(true);
            }
            foreach(GameObject t in TurnOffAtSingleplayer)
            { 
                t.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject t in TurnOnAtMultiplayer)
            {
                t.SetActive(true);
            }
            foreach (GameObject t in TurnOffAtMultiplayer)
            {
                t.SetActive(false);
            }
        }
    }
}
