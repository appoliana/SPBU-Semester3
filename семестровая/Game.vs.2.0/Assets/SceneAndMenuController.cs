using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndMenuController : MonoBehaviour { 

    public GameObject buttonsMenu;
    public GameObject buttonsExit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
}
