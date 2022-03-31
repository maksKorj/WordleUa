using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationInitializer : MonoBehaviour
{
    private void Awake()
    {
        Vibration.Init();
    }
}
