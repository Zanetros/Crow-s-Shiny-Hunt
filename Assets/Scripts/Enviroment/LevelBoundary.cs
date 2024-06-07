using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3f;
    public static float rightSide = 3f;
    public static float bottomSide = 0.25f;
    public static float topSide = 4f;

    public float internalLeft;
    public float internalRight;
    public float internalTop;
    public float internalBottom;
    
    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
        internalTop = topSide;
        internalBottom = bottomSide;
    }
}
