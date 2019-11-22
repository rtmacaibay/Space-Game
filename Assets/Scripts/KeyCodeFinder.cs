using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCodeFinder : MonoBehaviour
{
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            print("Detected key code: " + e.keyCode);
        }
    }
}
