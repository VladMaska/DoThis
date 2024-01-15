using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    
    public Vector3 point;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    private NavMeshAgent _agent;
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start() =>_agent = this.gameObject.GetComponent<NavMeshAgent>();

    private void Update(){
        
        if ( !Input.GetMouseButtonDown( 0 ) ) return;
        
        var ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        
        if ( !Physics.Raycast( ray, out var hit ) ) return;
        
        point = hit.point;
        point.y = 0;

        _agent.SetDestination( point );
        
    }

}