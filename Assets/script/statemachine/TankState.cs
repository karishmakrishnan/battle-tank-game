using UnityEngine;

public class TankState : MonoBehaviour
{
    public virtual void OnEnterState() { }
    public virtual void OnExitState() { }
    public virtual void Tick() { }
}
