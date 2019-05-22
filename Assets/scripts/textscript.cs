using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class textscript : MonoBehaviour
{

    int value;
    TextMeshProUGUI objective;

    // Start is called before the first frame update
    void Start()
    {
        objective = GetComponent<TextMeshProUGUI>();
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    public void cur(float current )
    {
        objective.text = current.ToString();
    }
}
