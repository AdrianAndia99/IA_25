using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Action")]
public class ActionNodeShoot : ActionNodeAction
{
     

    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Thief:
                //if (_IACharacterActions is IACharacterActions)
                //{
                //    ((IACharacterActionsZombie)_IACharacterActions).Attack();
                //}

                break;
            case UnitGame.Soldier:
                if (_IACharacterActions is IACharacterActionsSoldier)
                {
                    ((IACharacterActionsSoldier)_IACharacterActions).Shoot();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }
}