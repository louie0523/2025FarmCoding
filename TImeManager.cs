using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImeManager : MonoBehaviour
{
    public static TImeManager instance;

    public float currentTime;
    public float timeSpeed = 5f;
    public Material Sky;
    public float SkyMatMax = 5.2f;
    public float SkyMatMin = 1.8f;
    public Light DefaultLight;
    public Color MaxLightColor;
    public Color MinLightColor;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        currentTime += (1f / timeSpeed) * Time.deltaTime;
        if(currentTime >= 24)
        {
            currentTime = 0;
        }

        TimeSet();
    }

    void TimeSet()
    {
        Sky = RenderSettings.skybox;

        float t = Mathf.Sin(Mathf.PI * currentTime / 24f);

        float ex = Mathf.Lerp(SkyMatMin, SkyMatMin, t);
    }
}
