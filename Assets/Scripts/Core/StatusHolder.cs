using UnityEngine;

public class StatusHolder : MonoBehaviour 
{
    [SerializeField] State state;

    public State GetState()
    {
        return state;
    }

    public void SetState(State stateToSet)
    {
        state = stateToSet;
    }
}

public enum State
{
    idle, fight, move
}