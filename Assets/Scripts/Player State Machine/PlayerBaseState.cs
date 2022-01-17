using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager _player);

    public abstract void UpdateState(PlayerStateManager _player);

    public abstract void FixedUpdateState(PlayerStateManager _player);

    public abstract void OnTriggerEnter(PlayerStateManager _player, Collider _collider);
}
