using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Button mainMenuButton;

    public Canvas mainCanvas;
    public Canvas optionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(BackToMainMenuFromOptions);
    }

    void BackToMainMenuFromOptions()
    {
        mainCanvas.enabled = true;
        optionsCanvas.enabled = false;
    }
}
