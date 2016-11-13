using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

    public Canvas mainCanvas;
    public Canvas helpMen;
    public Button backGame;
    public Button mainMen;
    public Button helpMenuBtn;
    private bool isPaused;
    public GameObject Player;


	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        mainCanvas = mainCanvas.GetComponent<Canvas>();
        helpMen = helpMen.GetComponent<Canvas>();
        backGame = backGame.GetComponent<Button>();
        mainMen = mainMen.GetComponent<Button>();
        helpMenuBtn = helpMenuBtn.GetComponent<Button>();
        isPaused = false;
        mainCanvas.enabled = false;
        helpMen.enabled = false;
        backGame.enabled = false;
        mainMen.enabled = false;
        helpMenuBtn.enabled = false;
        helpMen.enabled = false;
        
    }

    public void HelpPress()
    {
        helpMen.enabled = true;
        backGame.enabled = false;
        mainMen.enabled = false;
        helpMenuBtn.enabled = false;
        Cursor.visible = true;

    }

    public void BackToPause()
    {
        helpMen.enabled = false;
        backGame.enabled = true;
        mainMen.enabled = true;
        helpMenuBtn.enabled = true;
        Cursor.visible = true;
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }




	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Time.timeScale = 0;
            PauseWorld();
            Cursor.visible = true;
            Player.GetComponent<FirstPersonController>().enabled = false;
            //helpMen.enabled = true;
            helpMenuBtn.enabled = true;
            backGame.enabled = true;
            mainMen.enabled = true;
        }
        else if (Time.timeScale == 0 && isPaused == false)
        {
            Time.timeScale = 1;
            ReturnWorld();
            Cursor.visible = false;
            Player.GetComponent<FirstPersonController>().enabled = true;
        }
	}

    public void PauseWorld()
    {
        mainCanvas.enabled = true;
        helpMen.enabled = false;
        backGame.enabled = true;
        mainMen.enabled = true;
        helpMenuBtn.enabled = true;
        Cursor.visible = true;
    }

    public void ReturnWorld()
    {
        mainCanvas.enabled = false;
        helpMen.enabled = false;
        backGame.enabled = false;
        mainMen.enabled = false;
        helpMenuBtn.enabled = false;
        isPaused = false;
    }
}
