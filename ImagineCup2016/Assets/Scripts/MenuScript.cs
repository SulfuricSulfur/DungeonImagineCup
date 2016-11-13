using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    public Canvas credits;
    public Button backBtn;
    public Button startBtn;
    public Button quitBtn;
    public Button creditsBtn;

	// Use this for initialization
	void Start () {
        credits = credits.GetComponent<Canvas>();
        startBtn = startBtn.GetComponent<Button>();
        backBtn = backBtn.GetComponent<Button>();
        creditsBtn = creditsBtn.GetComponent<Button>();
        quitBtn = creditsBtn.GetComponent<Button>();
        credits.enabled = false;
	}

    public void CreditsPress()
    {
        credits.enabled = true;
        backBtn.enabled = true;
        startBtn.enabled = false;
        creditsBtn.enabled = false;
        quitBtn.enabled = false;
    }

    public void BackPress()
    {
        credits.enabled = false;
        creditsBtn.enabled = true;
        backBtn.enabled = false;
        startBtn.enabled = true;
        quitBtn.enabled = true;
    }

    public void StartLvl()
    {
        SceneManager.LoadScene("level_1");
    }

    public void Exit()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        Cursor.visible = true;
    }

    
}
