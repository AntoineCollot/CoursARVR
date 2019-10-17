using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [Range(0,1)]
    public float intensity;
    public Color highlightColor;
    public Material[] materials;

    private void LateUpdate()
    {
        SetIntensity(intensity);
    }

    void SetIntensity(float value)
    {
        foreach(Material m in materials)
        {
            highlightColor.a = value;
            m.SetColor("_HighlightColor", highlightColor);
        }
    }
}
