using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CanvasScript : MonoBehaviour, IPointerUpHandler
{
    
    public TextMeshProUGUI goal, current, levelValue, gameModeValue;

    public Image background;
    
    public GameController _gameController ;

    public Slider slider;
    

    void Start()
    {
        //get the game controller
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
        
        //get the slider
        slider = GetComponentInChildren<UnityEngine.UI.Slider>();
        
        //set the UI variables according to the game controller
        levelValue = GameObject.Find("level").GetComponent<TextMeshProUGUI>();
        //levelValue.text = _gameController.Level.ToString();
        
        gameModeValue = GameObject.Find("mode").GetComponent<TextMeshProUGUI>();
        gameModeValue.text = _gameController.Mode.ToString();

        goal = GameObject.Find("goaltxt").GetComponent<TextMeshProUGUI>();
        //goal.text = "Reach " + _gameController.goalValue.ToString();
        
        current = GameObject.Find("currenttxt").GetComponent<TextMeshProUGUI>();
        current.text = slider.value.ToString();
        current.color = new Color(158, 158, 158, 0.3f);

        background = GetComponentInChildren<Image>();
        background.color = UnityEngine.Color.grey; 

    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        check();
    }

    public void check()
    {
        Debug.Log("onpointerup, slider value :" + slider.value);
        _gameController.CheckValue((int) slider.value); //send the slider value to the game controller to check if its correct
        if (_gameController.LevelCompleted)
        {
            
        }
    }

    
}
