using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public float leftSide = -3f;
    public float rightSide = 3f;
    public float bottomSide = 0.25f;
    public float topSide = 4f;

    public float internalLeft;
    public float internalRight;
    public float internalTop;
    public float internalBottom;

    public static LevelBoundary instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
        internalTop = topSide;
        internalBottom = bottomSide;
    }
}
