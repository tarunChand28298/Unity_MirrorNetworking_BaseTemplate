using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    GameObject playerToSpawn;

    GameObject controlledPawn;
    Camera mainCamera;

    void Start()
    {
        if (!hasAuthority) return;

        CmdCreatePlayerPawnOnServer();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!hasAuthority) return;
     
        if(Input.GetMouseButton(0))
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane viewPlane = new Plane(-Vector3.forward, Vector3.zero);

            float hitDistance;
            viewPlane.Raycast(cameraRay, out hitDistance);
            Vector3 hitPosition = (cameraRay.origin) + (hitDistance * cameraRay.direction);

            CmdMovePlayerPawn(hitPosition);
        }
    }

    [Command]
    void CmdCreatePlayerPawnOnServer()
    {
        controlledPawn = Instantiate(playerToSpawn, Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(controlledPawn, gameObject);
    }

    [Command]
    void CmdMovePlayerPawn(Vector3 hitPosition)
    {
        controlledPawn.GetComponent<NetworkPosition>().position = hitPosition;
    }
}
