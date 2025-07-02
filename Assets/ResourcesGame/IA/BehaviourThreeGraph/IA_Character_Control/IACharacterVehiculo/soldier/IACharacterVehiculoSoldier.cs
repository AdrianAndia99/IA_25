using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoSoldier : IACharacterVehiculoHuman
{

     
    void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);
    }
    public override void MoveToEnemy()
    {
        base.MoveToEnemy( );
    }
    public override void MoveToAllied()
    {
        base.MoveToAllied( );
    }
    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy( );
    }
    public override void MoveToStrategy()
    {
        
        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = Vector3.zero; 
        normales = ColliderWall();
        if (normales != Vector3.zero)
            dir = normales;
        else
        {
            dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        }
        Vector3 newPosition = transform.position + dir*2;
        MoveToPosition(newPosition );
        
        
    }

    private void OnDrawGizmos()
    {
        base.DrawGizmos();
    }
}
