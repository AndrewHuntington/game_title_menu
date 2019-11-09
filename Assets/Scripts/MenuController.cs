﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    private int cursorPosition = 0;
    [SerializeField] GameObject[] CursorObjects;
    GameObject currentCursorState;
    GameObject previousCursorState;
    Vector2 grabInputValue;

    // Start is called before the first frame update
    void Start()
    {
        currentCursorState = CursorObjects[cursorPosition];
    }

    // Update is called once per frame
    void Update()
    {
        grabInputValue = Vector2.zero;
        grabInputValue.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Vertical"))
        {
            if (grabInputValue.y < 0 && cursorPosition < CursorObjects.Length - 1)
            {
                previousCursorState = CursorObjects[cursorPosition];

                cursorPosition = Mathf.Clamp(cursorPosition + 1, 0, CursorObjects.Length - 1);
                currentCursorState = CursorObjects[cursorPosition];

                currentCursorState.SetActive(true);
                previousCursorState.SetActive(false);
            }
        }
    }
}
