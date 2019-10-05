using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityController : MonoBehaviour
{
    public Material target;
    public void UpdateOpacity(float alphaValue)
    {
        Color color = target.color;
        color.a = alphaValue;
        target.color = color;
    }
}
