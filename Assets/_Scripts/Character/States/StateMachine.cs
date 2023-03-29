using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public IState currentState;
    public IState newState;


    // Update is called once per frame
    public void UpdateState()
    {
        if (currentState != null)
        {

            if (newState == null)
            {
                currentState.Execute();
            }
            else
            {
                //Debug.Log(newState);
                ChangeState(newState);
                newState = null;
            }
        }
    }

    private void ChangeState(IState newState)
    {
        if (newState == null)
        {
            Debug.Log("newState is Null");
            return;
        }

        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
}


