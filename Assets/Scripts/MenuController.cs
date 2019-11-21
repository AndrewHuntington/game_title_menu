using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    private int cursorPosition = 0;
    [SerializeField] GameObject[] CursorObjects;
    [Tooltip("Sound when moving the cursor between selections")] [SerializeField] AudioClip blipSFX;
    [Tooltip("Sound when trying to move the cursor out-of-bounds")] [SerializeField] AudioClip deadZoneSFX;
    GameObject currentCursorState;
    GameObject previousCursorState;
    Vector2 grabInputValue;
    AudioSource audioSource;
    bool canControl = true;

    // Start is called before the first frame update
    void Start()
    {
        currentCursorState = CursorObjects[cursorPosition];
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Vertical") && canControl)
        {
            MenuSelect();
        }
    }

    private void MenuSelect()
    {
        grabInputValue = Vector2.zero;
        grabInputValue.y = Input.GetAxisRaw("Vertical");

        if (grabInputValue.y < 0 && cursorPosition < CursorObjects.Length - 1)
        {
            audioSource.PlayOneShot(blipSFX);
            previousCursorState = CursorObjects[cursorPosition];

            cursorPosition = Mathf.Clamp(cursorPosition + 1, 0, CursorObjects.Length - 1);
            currentCursorState = CursorObjects[cursorPosition];

            currentCursorState.SetActive(true);
            previousCursorState.SetActive(false);
        }
        else if (grabInputValue.y > 0 && cursorPosition > 0)
        {
            audioSource.PlayOneShot(blipSFX);
            previousCursorState = CursorObjects[cursorPosition];

            cursorPosition = Mathf.Clamp(cursorPosition - 1, 0, CursorObjects.Length - 1);
            currentCursorState = CursorObjects[cursorPosition];

            currentCursorState.SetActive(true);
            previousCursorState.SetActive(false);
        }
        else
        {
            // TODO: Figure out a way to stop this sound from playing if someone is already
            //       holding down one of the vertical buttons...
            audioSource.PlayOneShot(deadZoneSFX);
        }
    }
}
