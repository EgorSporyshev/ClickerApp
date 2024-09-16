using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpriteResize : MonoBehaviour
{
    public Button b1;
    private Vector3 originalScale;

    private float scaleFactor = 0.85f; // Уменьшение на 15%
    private bool isResizing = false;

    private void Start()
    {
        originalScale = transform.localScale; // Сохраняем исходный размер спрайта
        isResizing = false;
    }

    public void OnPointerDown()
    {
        isResizing = true;
    }
    public void OnPointerUp()
    {
        isResizing = false;
    }


    private void Update()
    {       
        //if (Input.GetMouseButtonDown(0)) // Если нажата левая кнопка мыши
        if (isResizing) { 
            //isResizing = true;
            // Уменьшаем размер спрайта
            transform.localScale = originalScale * scaleFactor;
        } else
        {
            transform.localScale = originalScale;
        }

        //if (Input.GetMouseButtonUp(0)) // Если отпущена левая кнопка мыши
        //{
        //    isResizing = false;
        //    // Возвращаем исходный размер спрайта
        //    transform.localScale = originalScale;
        //}
    }
}
