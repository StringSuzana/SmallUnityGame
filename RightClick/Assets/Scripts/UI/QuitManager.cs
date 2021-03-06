using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    [SerializeField]
    private Canvas ExitMenu;
    void Start()
    {
       // ExitMenu = GameObject.FindGameObjectWithTag(CanvasNames.exitMenu).GetComponent<Canvas>();
        ExitMenu.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            Debug.Log("Quitting the Game");
            ExitMenu.enabled = !ExitMenu.enabled;
        }
    }
    public void CloseMenu()
    {
        ExitMenu.enabled = false;
    }
    public void QuitGame()
    {
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
    }
}

