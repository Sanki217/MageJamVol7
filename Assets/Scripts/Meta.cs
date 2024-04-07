using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Meta : MonoBehaviour
{

    private bool HasSomeoneWon=false;
    public GameController Controller;
    public List<ParticleSystem> ParticleSystems;

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
                        SetParticles();
                        Debug.Log("someone whould win");
                    }
                    else
                    {
                        SetParticles();
                        Controller.Win("gracz lewy");
                    }
                }

                if (other.gameObject.GetComponent<FigaController>().PlayerNumber == 2)
                {
                    if (PlayerPrefs.HasKey("RightPlayerName"))
                    {
                        SetParticles();
                        Controller.Win(PlayerPrefs.GetString("RightPlayerName"));
                    }
                    else
                    {
                        SetParticles();
                        Controller.Win("gracz prawy");
                    }
                }
            }
            

            
        }
    }
    private void SetParticles()
    {
        foreach(var particle in ParticleSystems)
        {
            particle.Play();
        }
    }

}


