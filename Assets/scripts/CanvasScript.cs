using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CanvasScript : MonoBehaviour, IPointerUpHandler
{
    
    public TextMeshProUGUI goal, current, levelValue, gameModeValue;
    
    public GameController _gameController ;

    public Slider slider;
    

    void Start()
    {
        //get the game controller
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
        
        //get the slider
        slider = GetComponentInChildren<Slider>();
        
        //set the UI variables according to the game controller
        levelValue = GameObject.Find("level").GetComponent<TextMeshProUGUI>();
        levelValue.text = _gameController.Level.ToString();
        
        gameModeValue = GameObject.Find("mode").GetComponent<TextMeshProUGUI>();
        gameModeValue.text = _gameController.gamemode.ToString();

        goal = GameObject.Find("goaltxt").GetComponent<TextMeshProUGUI>();
        goal.text = "Reach " + _gameController.goalValue.ToString();
        
        current = GameObject.Find("currenttxt").GetComponent<TextMeshProUGUI>();
        current.text = slider.value.ToString();
        current.color = new Color(158, 158, 158, 0.3f);

    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        check();
    }

    public void check()
    {
        Debug.Log("onpointerup, slider value :" + slider.value);
        _gameController.CheckValue((int) slider.value); //send the slider value to the game controller to check if its correct
        if (_gameController.levelCompleted)
        {
            current.color = new Color(0, 255, 0, 0.3f);
        }
    }

    
    
    
    
}
