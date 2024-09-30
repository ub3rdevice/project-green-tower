using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[ExecuteAlways] //this makes this script to work both in editor and in playmode
public class NavigateLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coords = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>(); //preferably to cache this
        DisplayCoordsOnTile();
    }

    void Update()
    {

        if(!Application.isPlaying) //this condition makes this script to work only in editor since we don't want to update it during actual gameplay;
        {
            DisplayCoordsOnTile();
            UpdateObjectName();
        }

    }

    void DisplayCoordsOnTile()
    {
        coords.x = Mathf.RoundToInt((transform.parent.position.x) / UnityEditor.EditorSnapSettings.move.x);
        coords.y = Mathf.RoundToInt((transform.parent.position.z) / UnityEditor.EditorSnapSettings.move.z);

        //label.text = coords.x + "," + coords.y;
        label.text = coords.x + "," + coords.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coords.ToString();
    }
}
