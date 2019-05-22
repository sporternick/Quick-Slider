using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class canvasscript : MonoBehaviour, IPointerUpHandler
{
    int value;
    TextMeshProUGUI goal, current;

    void Start()
    {
        value = Random.Range(0, 100);
        goal = GetComponentsInChildren<TextMeshProUGUI>()[0];
        current = GetComponentsInChildren<TextMeshProUGUI>()[1];
        goal.text = value.ToString();
        current.text = GetComponentInChildren<Slider>().value.ToString();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        check();
    }

    public void check()
    {
        if(value == GetComponentInChildren<Slider>().value)
        {
            goal.color = new Color(0, 255, 0);
            Debug.Log("this is working");
        }
    }
}
