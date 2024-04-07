using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{

    private bool HasSomeoneWon=false;
    public GameController Controller;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Debug.Log("touched some balls");
            if (!HasSomeoneWon)
            {
                if (other.gameObject.GetComponent<FigaController>().PlayerNumber == 1)
                {
                    if (PlayerPrefs.HasKey("LeftPlayerName"))
                    {
                        Controller.Win(PlayerPrefs.GetString("LeftPlayerName"));
                        Debug.Log("someone whould win");
                    }
                    else
                    {
                        Controller.Win("gracz lewy");
                    }
                }

                if (other.gameObject.GetComponent<FigaController>().PlayerNumber == 2)
                {
                    if (PlayerPrefs.HasKey("RightPlayerName"))
                    {
                        Controller.Win(PlayerPrefs.GetString("RightPlayerName"));
                    }
                    else
                    {
                        Controller.Win("gracz prawy");
                    }
                }
            }
            

            
        }
    }
}
