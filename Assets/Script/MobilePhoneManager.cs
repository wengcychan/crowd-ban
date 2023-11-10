using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePhoneManager : MonoBehaviour
{
    void Awake()
    {
        if (Application.isMobilePlatform)
		{
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
        DontDestroyOnLoad(gameObject);
    }
}
