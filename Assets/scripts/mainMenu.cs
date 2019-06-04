using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * mainMenu
 * a class that handles the main menu of the game
 */
public class mainMenu : MonoBehaviour
{
    
    //menu toggles
    private Toggle gameModeToggleSpeed;
    private Toggle gameControlToggleScreen;
    private Toggle thumbSideToggle;
    public GameController _gameController;

    
    
    

    void Start()
    {
        
        //get the menu controls
        thumbSideToggle = GameObject.Find("ThumbSideToggle").GetComponent<Toggle>();
        gameModeToggleSpeed = GameObject.Find("SpeedyMode").GetComponent<Toggle>();
        gameControlToggleScreen = GameObject.Find("ScreenControl").GetComponent<Toggle>();
        
        //set the game settings according to which toggles are enabled by default in Unity (property .isOn)
        setThumbSide();
        setGameControl();
        setGameMode();
    }

    
    public void setThumbSide()
    {
        _gameController.ThumbSide = thumbSideToggle.isOn ? ThumbSide.Left : ThumbSide.Right;
    }
    
    public void setGameMode()
    {
        _gameController.Mode = gameModeToggleSpeed.isOn ? Mode.Accuracy : Mode.Speedy;
    }
    
    public void setGameControl()
    {
        _gameController.SliderMode = gameControlToggleScreen.isOn ? sliderMode.Vertical : sliderMode.Radial;
    }
    
    public void StartGame()
    {
        if (gameControlToggleScreen.isOn)
        {
            SceneManager.LoadScene("normalslider");
        }
        else
        {
            SceneManager.LoadScene("circleslider");
        }
    }
    
   
}
