 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerGravityState gravityState = new PlayerGravityState();
    public PlayerZeroGravityState zeroGravityState = new PlayerZeroGravityState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = gravityState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        currentState.OnTriggerEnter(this, _collider);
    }
}
