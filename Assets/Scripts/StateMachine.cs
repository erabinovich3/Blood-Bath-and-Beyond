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

    public void changeState(State state, params object[] values)
    {
        
        curState.OnExit();
        setCurState(state, values);
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
        curState = s;
        s.OnEnter(values);
        
    }
}


abstract public class State {
    public StateMachine parent;
    public State(StateMachine p)
    {
        parent = p;
    }
    public abstract void Execute();
    public abstract void OnEnter(params object[] values);
    public abstract void OnExit();
}
