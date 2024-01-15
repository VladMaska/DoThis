using System;
using UnityEngine;
using UnityEngine.AI;

public class SScript : Enemy {

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private EnemyStatus _sphereMode = EnemyStatus.Walk;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public SScript( NavMeshAgent sphereObj ) => base.EnemyObj = sphereObj;

    public override void UpdateEnemy( Transform playerObj ){
        
        var distance = ( base.EnemyObj.gameObject.transform.position - playerObj.position ).magnitude;

        switch ( _sphereMode ){
            
            case EnemyStatus.Walk:
                
                if ( distance < 10f )
                    _sphereMode = EnemyStatus.Run;
                
                break;
            
            case EnemyStatus.Run:
                
                if ( distance > 10f )
                    _sphereMode = EnemyStatus.Walk;

                break;
            
            default:
                throw new ArgumentOutOfRangeException();
            
        }
        
        DoAction( playerObj, _sphereMode );
        
    }

}