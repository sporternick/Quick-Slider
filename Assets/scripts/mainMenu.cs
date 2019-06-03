using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * mainMenu
 * a class that handles the main menu of the game
 */
public class MainMenu : MonoBehaviour
{
    
    //menu toggles
    private Toggle _gameModeToggleSpeed;
    private Toggle _gameControlToggleScreen;
    private Toggle _thumbSideToggle;
    private GameController _gameController;

    
    void Start()
    {
        //get the game controller
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
        
        //get the menu controls
        _thumbSideToggle = GameObject.Find("ThumbSideToggle").GetComponent<Toggle>();
        _gameModeToggleSpeed = GameObject.Find("SpeedyMode").GetComponent<Toggle>();
        _gameControlToggleScreen = GameObject.Find("ScreenControl").GetComponent<Toggle>();
        
        //set the game settings according to which toggles are enabled by default in Unity (property .isOn)
        SetThumbSide();
        SetGameControl();
        SetGameMode();
    }
    
    public void SetThumbSide()
    {
        _gameController.ThumbSide = _thumbSideToggle.isOn ? ThumbSide.Left : ThumbSide.Right;
    }
    
    public void SetGameMode()
    {
        _gameController.Mode = _gameModeToggleSpeed.isOn ? Mode.Speed : Mode.Accuracy;
    }
    
    public void SetGameControl()
    {
        _gameController.Slider = _gameControlToggleScreen.isOn ? Slider.Vertical : Slider.Radial;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }
    
   
}
