using Mirror;
using UnityEngine;

public class GameNetworkManager : NetworkManager
{
    public override void OnServerConnect(NetworkConnection connection)
    {
        base.OnServerConnect(connection);
    }

    public override void OnServerDisconnect(NetworkConnection connection)
    {
        base.OnServerDisconnect(connection);
    }
}
