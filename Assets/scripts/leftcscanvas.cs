﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftcscanvas : cscanvas
{
   public override void detect()
    {
     
        if (Input.touchCount > 0)
        {
            Vector3 touchpos = Input.mousePosition;


            float x = touchpos.x;
            float y = touchpos.y;

            float degrees = Mathf.Rad2Deg * Mathf.Atan(y / x);
            slider.Slider.rotation = Quaternion.Euler(0, 0, degrees);
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

