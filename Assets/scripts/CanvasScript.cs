﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Required when Using UI elements.
using System.Collections;

public class CanvasScript : MonoBehaviour, IPointerUpHandler
{

    public TextMeshProUGUI roundNumber, levelType, instructionsText;

    public GameObject startButton;


    public GameController GameController ;

    // SLIDER
    public GameObject SliderPrefab;
    public GameObject SliderObject;
    public UnityEngine.UI.Slider slider;

    public Level level;
    public Slider slider;

    private CSVmaker dataSaver = new CSVmaker();

    public Transform TouchArea;


    void Start()
    {

        GameController = GameObject.Find("gameController").GetComponent<GameController>();

        startButton = GameObject.Find("startButton");

        roundNumber = GameObject.Find("roundNumber").GetComponent<TextMeshProUGUI>();
        levelType = GameObject.Find("levelType").GetComponent<TextMeshProUGUI>();
        instructionsText = GameObject.Find("instructionsText").GetComponent<TextMeshProUGUI>();
    }


    public void ReloadUI()
    {
        Debug.Log("ReloadUI");

        SetRoundNumberText(GameController.GetRoundIndex());
        SetInstructionText(GameController.GetRoundInstructions());
        SetLevelTypeText(GameController.Mode);

        if(!slider) CreateSlider();
        //

        /*goal = GameObject.Find("goaltxt").GetComponent<TextMeshProUGUI>();
        goal.text = "Reach " + GameController.GetRoundGoal();



        background = GetComponentInChildren<Image>();
        background.color = UnityEngine.Color.grey;
        dataSaver.Init();
        background.color = Color.grey;*/
    }

    void CreateSlider()
    {
        //check for Slider type in gameController
        if (GameController.Slider == Slider.Vertical)
        {
            // Instantiate slider at position Vector3 and zero rotation, inside TouchArea gameobject
            SliderObject = Instantiate(SliderPrefab, new Vector3(Screen.width / 2, 150, 0), Quaternion.identity, TouchArea);
            slider = SliderObject.GetComponentInChildren<UnityEngine.UI.Slider>();
        }
        //instantiate the chosen slider with:
        //Instantiate(SliderPrefab, new Vector3(0, 0, 0), Quaternion.identity, TouchArea);
    }

    public void SetInstructionText(string instructions)
    {
        instructionsText.SetText(instructions);
    }

    public void SetRoundNumberText(int index)
    {
        roundNumber.SetText("Round " + index);
    }

    public void SetLevelTypeText(Mode mode)
    {
        levelType.SetText(mode + " level");
    }
    void Update()
    {
        goal.text = "Reach " + level.CurrentRound.Goal.ToString();
        levelValue.text = level.RoundNumber.ToString();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Check();
    }

    public void Check()
    {
        dataSaver.addEntry(level.CurrentRound.Goal, (int)slider.value);
        if (level.RoundNumber % 15 == 0)
        {
            dataSaver.SavetoCSV();
        }
        Debug.Log("onpointerup, slider value :" + slider.value);
        level.NextRound();

    }

    public void StartGame()
    {
        startButton.SetActive(false);
        GameController.StartLevel();
        ReloadUI();
    }

    public void StopGame()
    {
        startButton.SetActive(true);
        GameController.QuitLevel();
    }

    private void FixedUpdate()
    {
        //here we can log every value of the slider over time
        //Debug.Log("Update, slider value :" + slider.value);
    }
}
