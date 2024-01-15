using System;
using UnityEngine;
using UnityEngine.AI;

public class BScript : Enemy {

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private EnemyStatus _cubeMode = EnemyStatus.Walk;
    private Vector3 _point;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public BScript( NavMeshAgent cubeObj ) => base.EnemyObj = cubeObj;

    public override void UpdateEnemy( Transform playerObj ){
        
        var enemyPos = base.EnemyObj.gameObject.transform.position;
        
        var distance = ( enemyPos - playerObj.position ).magnitude;

        switch ( _cubeMode ){
            
            case EnemyStatus.Run:
                
                if ( distance < 10f )
                    _cubeMode = EnemyStatus.Walk;
                
                break;
            
            case EnemyStatus.Walk:
                
                if ( distance > 10f )
                    _cubeMode = EnemyStatus.Run;

                break;
            
            default:
                throw new ArgumentOutOfRangeException();
            
        }

        DoAction( playerObj, _cubeMode );
        
    }

}