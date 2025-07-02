using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZombie : IACharacterActions
{

 
    public int damageZombie;
    IAEyeZombieAttack _IAEyeZombieAttack;
    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        _IAEyeZombieAttack = ((IAEyeZombieAttack)AIEye);

    }
    public void DamageEnemy()
    {
        if (_IAEyeZombieAttack != null &&
                    _IAEyeZombieAttack.ViewEnemy != null)
        {

            _IAEyeZombieAttack.ViewEnemy.Damage(damageZombie, health);
        }

    }
    public void Attack()
    {
        ((ThirdPersonAnimationZombie)TPAnimation).Stop();
        ((ThirdPersonAnimationZombie)TPAnimation).Attack();
    }

    
}
