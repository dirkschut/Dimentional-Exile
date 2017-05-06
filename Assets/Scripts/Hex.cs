using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if(Q == 0 && R == 0)
        {
            Type = "Cell";
        }
        else
        {
            Type = "Void";
        }
    }

    public readonly int Q;  // Column
    public readonly int R;  // Row
    public readonly int S;  // Sum

    public string Name;  // The name of the Hex
    public string Type;

    public static Dictionary<string, int> HexTypes;

    public static readonly float border = 0.0f;  // The border between hexes
    public static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;  // The multiplier of the width of a hex compared to its height
    public static readonly float radius = 1;  // The radius of a hex

    public static readonly bool allowWrapHor = true;  // If the map is allowed to wrap horizontally
    public static readonly bool allowWrapVert = true;  // If the map is allowed to wrap vertically

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
    /// Get the Position of the Hex relative to the camera
    /// </summary>
    /// <param name="cameraPosition">The position of the camera</param>
    /// <param name="numRows">The amount of rows in the world</param>
    /// <param name="numColumns">The amount of columns in the world</param>
    /// <returns></returns>
    public Vector3 PositionFromCamera(Vector3 cameraPosition, float numRows, float numColumns)
    {
        float mapHeight = numRows * HexVericalSpacing();
        float mapWidth = numColumns * HexHorizontalSpacing();
        Vector3 pos = Position();

        if (allowWrapHor)
        {
            float numWidthsFromCamera = (pos.x - cameraPosition.x) / mapWidth;

            int numToMove = (int)Mathf.Round(numWidthsFromCamera);
            
            if(Mathf.Abs(numToMove) >= 1)
            {
                pos.x -= numToMove * mapWidth;
            }
        }

        if (allowWrapVert)
        {
            float numHeightsFromCamera = (pos.z - cameraPosition.z) / mapHeight;

            int numToMove = (int)Mathf.Round(numHeightsFromCamera);

            if (Mathf.Abs(numToMove) >= 1)
            {
                pos.z -= numToMove * mapHeight;
            }
        }

        return pos;
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

    /// <summary>
    /// Gets called when the mouse enters the hex from the child
    /// </summary>
    public void Hover()
    {
        GameObject.Find("HoverInfoName").GetComponent<Text>().text = "Name: " + Name;
        GameObject.Find("HoverInfoPosition").GetComponent<Text>().text = "Position: " + R + "," + Q;
    }

    /// <summary>
    /// Gets called when the mouse is clicked on this hex from the child
    /// </summary>
    public void Click()
    {
        GameObject.Find("HexInfo").GetComponent<HexInfoComponent>().Hex = this;
    }
}
