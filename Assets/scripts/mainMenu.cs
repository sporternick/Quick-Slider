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
    private Toggle gameControlToggleVertical;
    private Toggle thumbSideToggle;
    public GameController _gameController;

    void Start()
    {
        //get game controller
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
        
        //get the menu controls
        thumbSideToggle = GameObject.Find("ThumbSideToggle").GetComponent<Toggle>();
        gameModeToggleSpeed = GameObject.Find("SpeedyMode").GetComponent<Toggle>();
        gameControlToggleVertical = GameObject.Find("VerticalControl").GetComponent<Toggle>();

        SetGameSettings();
    }


    public void SetGameSettings()
    {
        //set the game settings according to which toggles are enabled by default in Unity (property .isOn)
        setThumbSide();
        setGameControl();
        setGameMode();
    }
    
    public void setThumbSide()
    {
        if (!_gameController) return ;
        _gameController.ThumbSide = thumbSideToggle.isOn ? ThumbSide.Left : ThumbSide.Right; //toggle on = left handed
    }
    
    public void setGameMode()
    {
        if (!_gameController) return ;
        _gameController.Mode = gameModeToggleSpeed.isOn ? Mode.Speedy : Mode.Accuracy ;
    }
    
    public void setGameControl()
    {
        if (!_gameController) return ;
        _gameController.SliderMode = gameControlToggleVertical.isOn ? SliderMode.Vertical : SliderMode.Radial;
    }
    
    public void StartGame()
    {
        SetGameSettings();
        _gameController.StartLevel();
        if (_gameController.SliderMode == SliderMode.Vertical)
        {
            Debug.Log("slider is set to vertical, loading normal slider");
            SceneManager.LoadScene("normalslider");
        }
        else
        {
            Debug.Log("slider is set to radial, loading radial slider");

            if (thumbSideToggle.isOn)
            {
                SceneManager.LoadScene("leftcircleslider");
            }
            else
            {
                SceneManager.LoadScene("circleslider");
            }
            
        }
    }
    
   
}
