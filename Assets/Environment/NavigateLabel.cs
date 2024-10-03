using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Windows;


[ExecuteAlways] //this makes this script to work both in editor and in playmode
[RequireComponent(typeof(TextMeshPro))]
public class NavigateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    TextMeshPro label;
    Vector2Int coords = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>(); //preferably to cache this   
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordsOnTile();
    }

    void Update()
    {

        if(!Application.isPlaying) //this condition makes this script to work only in editor since we don't want to update it during actual gameplay;
        {
            DisplayCoordsOnTile();
            UpdateObjectName();
            label.enabled = true;
        }
        SetLabelColor();
        SwitchLabels();

    }

    void SwitchLabels()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if(waypoint.IsValidForPlacement)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordsOnTile()
    {
        coords.x = Mathf.RoundToInt((transform.parent.position.x) / UnityEditor.EditorSnapSettings.move.x); // UnityEditor methods won't allow build to be compiled, we should either comment these lines or move this script to the "Editor" dir BEFORE compiling the build
        coords.y = Mathf.RoundToInt((transform.parent.position.z) / UnityEditor.EditorSnapSettings.move.z);

        //label.text = coords.x + "," + coords.y;
        label.text = coords.x + "," + coords.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coords.ToString();
    }
}
