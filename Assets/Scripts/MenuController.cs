using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    private int cursorPosition = 0;
    [SerializeField] GameObject[] CursorObjects;
    [Tooltip("Sound when moving the cursor")] [SerializeField] AudioClip blipSFX;
    GameObject currentCursorState;
    GameObject previousCursorState;
    Vector2 grabInputValue;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentCursorState = CursorObjects[cursorPosition];
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MenuSelect();
    }

    private void MenuSelect()
    {
        grabInputValue = Vector2.zero;
        grabInputValue.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Vertical"))
        {
            audioSource.PlayOneShot(blipSFX);

            if (grabInputValue.y < 0 && cursorPosition < CursorObjects.Length - 1)
            {
                previousCursorState = CursorObjects[cursorPosition];

                cursorPosition = Mathf.Clamp(cursorPosition + 1, 0, CursorObjects.Length - 1);
                currentCursorState = CursorObjects[cursorPosition];

                currentCursorState.SetActive(true);
                previousCursorState.SetActive(false);
            }

            if (grabInputValue.y > 0 && cursorPosition > 0)
            {
                previousCursorState = CursorObjects[cursorPosition];

                cursorPosition = Mathf.Clamp(cursorPosition - 1, 0, CursorObjects.Length - 1);
                currentCursorState = CursorObjects[cursorPosition];

                currentCursorState.SetActive(true);
                previousCursorState.SetActive(false);
            }
        }
    }
}
