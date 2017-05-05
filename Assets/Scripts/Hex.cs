using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the various coordinates of the hexes
/// </summary>
public class Hex
{

    /// <summary>
    /// Create a Hex object with a Qolumn and Row
    /// </summary>
    /// <param name="q">Column</param>
    /// <param name="r">Row</param>
    public Hex(int q, int r)
    {
        Q = q;
        R = r;
        S = -(q + r);
    }

    public readonly int Q;  // Column
    public readonly int R;  // Row
    public readonly int S;  // Sum

    public float border = 0.1f;

    public static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

    public static float radius = 1;

    /// <summary>
    /// Calculates the position of the hex in the unity world space
    /// </summary>
    /// <returns>The position of the hex</returns>
    public Vector3 Position()
    {
        return new Vector3(
            HexHorizontalSpacing() * (Q + R/2f),
            0,
            HexVericalSpacing() * R
            );
    }

    /// <summary>
    /// Get the vertical spacing of the hex
    /// </summary>
    /// <returns></returns>
    private float HexVericalSpacing()
    {
        return HexHeight() * 0.75f;
    }

    /// <summary>
    /// Get the Horizontal spacing of the hex
    /// </summary>
    /// <returns></returns>
    private float HexHorizontalSpacing()
    {
        return HexWidth() + border * WIDTH_MULTIPLIER;
    }

    /// <summary>
    /// Get the width of the hex
    /// </summary>
    /// <returns></returns>
    private float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }

    /// <summary>
    /// Get the height of the hex
    /// </summary>
    /// <returns></returns>
    private float HexHeight()
    {
        return radius * 2 + border;
    }
}
