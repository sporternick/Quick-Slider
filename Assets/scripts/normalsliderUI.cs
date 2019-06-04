using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class normalsliderUI : MonoBehaviour
{

    public Level level;
    public TextMeshProUGUI leveltxt, modetxt, goaltxt;
    

    // Start is called before the first frame update
    void Start()
    {
        leveltxt.text = level.CurrentRound.ToString();
        modetxt.text = level._mode.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
   
}
