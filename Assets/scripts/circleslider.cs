using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class circleslider : MonoBehaviour { 
    public int value, min = 0, max = 100;
    private RectTransform Slider;

    void Start()
    {
        Slider = GetComponent<RectTransform>();
      
    }
   
        // Update is called once per frame
        void Update()
    {

        if (Input.touchCount > 0) { 
            Vector3 touchpos = Input.mousePosition;


            float x = 1080 - touchpos.x;
            float y = touchpos.y;

            float degrees = Mathf.Rad2Deg * Mathf.Atan(y / x);
            Slider.rotation =  Quaternion.Euler(0, 0, -degrees);
            value = Mathf.RoundToInt(max *degrees/90);
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Slider.rotation = Quaternion.Euler(0, 0, 0);
                //submit current value 
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
                
        }

       
        
        
    }
    
}

