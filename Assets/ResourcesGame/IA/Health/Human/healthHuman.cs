using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHuman : Health
{
    [Header("Food")]
    public float Food;
    [Header("Water")]
    public float Water;
    public override void LoadComponent()
    {
        base.LoadComponent();
        Food = Water = 50;
    }
    public void SetFood(float food)
    {
        Food += food;
    }
    public void SetWater(float water)
    {
        Water += Water;
    }
    public void UpdateHunger()
    {
         Food -= 10f;
    }
    public void UpdateThirst()
    {
        Water -= 10f;
    }
}
