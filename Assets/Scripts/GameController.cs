using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    [Space]
    public GameObject playerObj;
    [Space]
    public NavMeshAgent sphereObj;
    public NavMeshAgent cubeObj;
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    private readonly List<Enemy> _enemies = new List<Enemy>();

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start(){
    
        _enemies.Add( new SScript( sphereObj ) );
        _enemies.Add( new BScript( cubeObj ) );
        
    }

    private void Update(){
        
        foreach ( var enemy in _enemies )
            enemy.UpdateEnemy( playerObj.transform );
        
    }

}