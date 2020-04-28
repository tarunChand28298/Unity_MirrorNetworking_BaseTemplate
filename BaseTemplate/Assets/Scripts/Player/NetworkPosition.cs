using Mirror;
using UnityEngine;

public class NetworkPosition : NetworkBehaviour
{
    [SyncVar(hook =nameof(UpdatePosition))]
    public Vector3 position;

    public void UpdatePosition(Vector3 oldValue, Vector3 newValue)
    {
        transform.position = newValue;
    }
}
