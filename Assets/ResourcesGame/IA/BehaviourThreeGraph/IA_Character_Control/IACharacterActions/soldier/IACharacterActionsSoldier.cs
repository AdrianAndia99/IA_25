using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsSoldier : IACharacterActions
{

    float FrameRate = 0;
    public float Rate=1;
    public int damageSoldier;
 

    void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void Attack()
    {
       
        if (FrameRate > Rate)
        {
            FrameRate = 0;
            IAEyeSoldierShootAttack _IAEyeSoldierAttack = (IAEyeSoldierShootAttack)AIEye;
          
            if (_IAEyeSoldierAttack != null &&
                _IAEyeSoldierAttack.ViewEnemy != null)
            {
                
                _IAEyeSoldierAttack.ViewEnemy.Damage(damageSoldier, health);
            }
        }
        FrameRate += Time.deltaTime;
    }
    public void Shoot()
    {
        if (FrameRate > Rate)
        {
            FrameRate = 0;
            
        }
        FrameRate += Time.deltaTime;
    }
}