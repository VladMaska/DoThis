using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy {
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    protected NavMeshAgent EnemyObj;
    
    protected enum EnemyStatus {
        Run,
        Walk
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public virtual void UpdateEnemy( Transform playerObj ){ }
    
    protected void DoAction( Transform playerObj, EnemyStatus enemyMode ){

        const float walkSpeed = 1f;
        const float runSpeed = walkSpeed * 2;

        switch ( enemyMode ){
            
            case EnemyStatus.Walk:

                EnemyObj.speed = walkSpeed;
                EnemyObj.SetDestination( playerObj.position );
                
                break;
            
            case EnemyStatus.Run:

                EnemyObj.speed = runSpeed;
                EnemyObj.SetDestination( playerObj.position );
                
                break;

            default:
                throw new ArgumentOutOfRangeException( nameof( enemyMode ), enemyMode, null );
            
        }

    }

}