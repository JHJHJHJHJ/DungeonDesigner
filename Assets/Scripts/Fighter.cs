using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour, IAction
{
    [SerializeField] float attackRange = 1f;
    [SerializeField] Transform target;

    private void Start() 
    {

    }

    private void Update() 
    {
        if(target == null) return;

        if(!IsInRange())
        {   
            GetComponent<Mover>().MoveTo(target);
        }
        else
        {
            GetComponent<Mover>().Cancel();
        }
    }

    public void Attack(CombatTarget combatTarget)
    {
        GetComponent<ActionScheduler>().StartAction(this);
        target = combatTarget.transform;
    }

    bool IsInRange()
    {
        return ( Vector2.Distance(transform.position, target.transform.position) <= attackRange ); 
    }

    public void Cancel()
    {
        target = null;
    }
}
