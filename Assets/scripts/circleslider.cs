using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class circleslider : MonoBehaviour { 
    public int value, min = 0, max = 100;
    public RectTransform Slider;

    void Start()
    {
        Slider = GetComponent<RectTransform>();
    }

    
}

