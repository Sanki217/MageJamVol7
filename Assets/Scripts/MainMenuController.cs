using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public TMP_InputField LeftPlayerName;
    public TMP_InputField RightPlayerName;
    public TMP_Text Record;
    public TMP_Text RecordHolder;
    public Toggle singleplayerrToggle;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("PlayerNumber"))
        {
            if (PlayerPrefs.GetInt("PlayerNumber") == 1)
            {
                singleplayerrToggle.isOn = true;
            }
            else
            {
                singleplayerrToggle.isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("PlayerNumber", 2);
            singleplayerrToggle.isOn = false;
        }

        if (PlayerPrefs.HasKey("Record"))
        {
            Record.text = PlayerPrefs.GetFloat("Record").ToString();
            Debug.Log("record:" + PlayerPrefs.GetFloat("Record").ToString());
        }
        if (PlayerPrefs.HasKey("RecordHolder"))
        {
            RecordHolder.text = PlayerPrefs.GetString("RecordHolder");
            Debug.Log("record holder:" + PlayerPrefs.GetString("RecordHolder"));
        }

        if (PlayerPrefs.HasKey("LeftPlayerName"))
        {
            LeftPlayerName.text = PlayerPrefs.GetString("LeftPlayerName");
        }
        if (PlayerPrefs.HasKey("RightPlayerName"))
        {
            RightPlayerName.text = PlayerPrefs.GetString("RightPlayerName");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitGame();
        }
        /*if (Input.GetKey(KeyCode.Enter))
        {
            StartGame();
        }*/
    }
    public void StartGame()
    {
        if(LeftPlayerName != null)
        {
            PlayerPrefs.SetString("LeftPlayerName", LeftPlayerName.text);

        }
        if(RightPlayerName != null)
        {
            PlayerPrefs.SetString("RightPlayerName", RightPlayerName.text);
        }
        if (singleplayerrToggle == true)
        {
            PlayerPrefs.SetInt("PlayerNumber", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerNumber", 2);
        }
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        PlayerPrefs.SetString("LeftPlayerName", LeftPlayerName.text);
        PlayerPrefs.SetString("RightPlayerName", RightPlayerName.text);
        Application.Quit();
    }

    public void ClearRecord()
    {
        PlayerPrefs.DeleteKey("Record");
        PlayerPrefs.DeleteKey("RecordHolder");
        Record.text = "";
        RecordHolder.text = "";
    }
}
