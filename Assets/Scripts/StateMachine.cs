using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class StateMachine : MonoBehaviour
{
    private State[] stateList;
    private State curState;


    void Start()
    {

    }

    void Update()
    {

    }

    protected void changeState(State state, params object[] values)
    {
        
        curState.OnExit();
        curState = state;
        state.OnEnter(values);
    }

    public void setStateList(State[] toSet)
    {
        stateList = toSet;
    }
    public State getCurState()
    {
        return curState;
        
    }
    public void setCurState(State s, params object[] values)
    {
        Debug.Log("init called");
        curState = s;
        s.OnEnter(values);
        
    }
}


public abstract class State {

    public abstract void Execute();
    public abstract void OnEnter(params object[] values);
    public abstract void OnExit();
}
