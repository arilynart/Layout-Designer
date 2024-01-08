using UnityEngine;
using System;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public enum CardLand
    {
        PINES
    }

    public CardLand landType;

    public enum FrameType
    {
        MINIMUM,
        COST_ONLY,
        ATK_AND_DEF
    }

    public FrameType frame;

    public string title;
    public string type;
    public string artist;

    public int cost;

    public Sprite art;

    public int atk;
    public int def;

    [TextArea(10, 100)]
    public string text;


    public int textFont;
}