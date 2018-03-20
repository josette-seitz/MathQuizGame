using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject chalkboard;
    public GameObject menu;

    public void StartMenu()
    {
        chalkboard.SetActive(true);
        menu.SetActive(false);
    }
}
