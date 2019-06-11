using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CanvasScript : MonoBehaviour, IPointerUpHandler
{
    
    public TextMeshProUGUI goal, levelValue, gameModeValue;

    public Image background;
    
    public GameController _gameController ;

    public Level level;
    public Slider slider;

    private CSVmaker dataSaver;
    

    void Start()
    {
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
        dataSaver = new CSVmaker();
        dataSaver.Init();
        
        level  = _gameController.Level;

        levelValue.text = level.RoundNumber.ToString();
        gameModeValue.text = _gameController.Mode.ToString();

        goal.text = "Reach " + level.CurrentRound.Goal.ToString(); 
        
        background = GetComponentInChildren<Image>();
        background.color = UnityEngine.Color.grey;
    }
    
    void Update()
    {
        dataSaver.addEntry(level.CurrentRound.Goal, (int)slider.value, "screen update");
    }

    void UpdateUI()
    {
        goal.text = "Reach " + level.CurrentRound.Goal;
        levelValue.text = level.RoundNumber.ToString();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        check();
    }

    public void check()
    {
        dataSaver.addEntry(level.CurrentRound.Goal, (int)slider.value,"release of screen");
        level.NextRound();
        UpdateUI();
        if (level.Completed)
        {
            dataSaver.SavetoCSV();
        }
        Debug.Log("onpointerup, slider value :" + slider.value);
    }
    
}
