using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{

    public void GoToMainMenu()
    {
        GameManager.Instance.GoToMenuScene();
    }
}
