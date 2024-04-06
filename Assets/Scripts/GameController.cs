using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public TMP_Text LeftPlayerName;
    public TMP_Text RightPlayerName;
    public GameObject WinnerText;
    private bool hasSomeoneWon = false;
    public FigaController LeftPlayer;
    public FigaController RightPlayer;
    public TMP_Text TimeText;
    public float time=0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LeftPlayerName"))
        {
            LeftPlayerName.text = PlayerPrefs.GetString("LeftPlayerName");
        }
        else
        {
            LeftPlayerName.text = "left Player";
        }

        if (PlayerPrefs.HasKey("RightPlayerName"))
        {
            RightPlayerName.text = PlayerPrefs.GetString("RightPlayerName");
        }
        else
        {
            RightPlayerName.text = "right Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.Return) && hasSomeoneWon)
        {
            SceneManager.LoadScene(1);
        }

        time = time+Time.deltaTime;
        TimeText.text = (Mathf.Round(time * 100f) / 100f).ToString();
    }

    public void Win(string WinnerName)
    {
        WinnerText.GetComponent<TMP_Text>().text = WinnerName+" has won!";
        WinnerText.GetComponent<Animator>().SetBool("HasSomeoneWon", true);
        hasSomeoneWon = true;
        LeftPlayer.GameEnded = true;
        RightPlayer.GameEnded = true;
    }
}
