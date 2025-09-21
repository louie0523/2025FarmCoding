using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TImeManager : MonoBehaviour
{
    public static TImeManager instance;

    public float currentTime;
    public float timeSpeed = 5f;
    public PostProcessVolume voluem;
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
        ColorGrading colorGrading;
        voluem.profile.TryGetSettings<ColorGrading>(out colorGrading);

        float t = Mathf.Clamp01((Mathf.Sin((currentTime - 6f) * Mathf.PI / 12f) + 1f) * 0.5f);

        Color lightColor = Color.Lerp(MinLightColor, MaxLightColor, t);

        colorGrading.colorFilter.Override(lightColor);
    }
}
