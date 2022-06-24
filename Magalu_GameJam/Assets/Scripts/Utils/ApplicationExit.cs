using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationExit : MonoBehaviour
{
    public void Quit()
    {
        //We can add a popup asking the player if he wants to really quit
        Application.Quit();
    }
}