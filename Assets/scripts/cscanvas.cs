﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class cscanvas : MonoBehaviour
{
    public GameController _gameController;
    public TextMeshProUGUI level, mode, currentgoal;
    public circleslider slider;
    protected CSVmaker csvmaker ;
    // Start is called before the first frame update
    void Start()
    {
        csvmaker = new CSVmaker();
        _gameController = GameObject.Find("gameController").GetComponent<GameController>();
        mode.text = _gameController.Mode.ToString();
        csvmaker.Init();

    }

    // Update is called once per frame
    void Update()
    {
        level.text = _gameController.Level.RoundNumber.ToString();
        currentgoal.text = _gameController.Level.CurrentRound.Goal.ToString();
        csvmaker.addEntry(_gameController.Level.CurrentRound.Goal, slider.value, "screen update");
        detect();
    }

   public virtual void detect()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchpos = Input.mousePosition;


            float x = 1080 - touchpos.x;
            float y = touchpos.y;

            float degrees = Mathf.Rad2Deg * Mathf.Atan(y / x);
            slider.Slider.rotation = Quaternion.Euler(0, 0, -degrees);
            slider.value = Mathf.RoundToInt(slider.max * degrees / 90);
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //save update
                csvmaker.addEntry(_gameController.Level.CurrentRound.Goal, slider.value, "screen release");
                _gameController.Level.NextRound();
                if (_gameController.Level.Completed)
                {
                    csvmaker.SavetoCSV();
                }
            }
            

        }
    }
   
}
