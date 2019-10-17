using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementShader : MonoBehaviour
{
    public Shader replacementShader;
    public string shaderTag = "Replacement";

    void Start()
    {
        GetComponent<Camera>().SetReplacementShader(replacementShader, shaderTag);
    }
}
