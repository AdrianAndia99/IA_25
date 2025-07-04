using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]
public class ActionEvadeEnemy : ActionNodeVehicle
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Thief:
                    
                break;
            case UnitGame.Soldier:
                if (_IACharacterVehiculo is IACharacterVehiculoSoldier)
                {
                    ((IACharacterVehiculoSoldier)_IACharacterVehiculo).MoveToEvadEnemy();
                }
                break;
            case UnitGame.Civil:
                if (_IACharacterVehiculo is IACharacterVehiculoCivil)
                {
                    ((IACharacterVehiculoCivil)_IACharacterVehiculo).MoveToEvadEnemy();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }

}