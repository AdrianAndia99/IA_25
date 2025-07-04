using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoCivil : IACharacterVehiculoHuman
{
    
    // Start is called before the first frame update
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
        base.MoveToStrategy();
    }
    private void OnDrawGizmos()
    {
        base.DrawGizmos();
    }


}
