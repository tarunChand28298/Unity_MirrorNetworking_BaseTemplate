using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    NetworkManager networkManager;

    [SerializeField]
    InputField ipAddressField;

    [SerializeField]
    GameObject connectElements;
    [SerializeField]
    GameObject disconnectElements;

    bool isHosting;

    public void OnHostButtonClick()
    {
        isHosting = true;
        networkManager.StartHost();

        connectElements.SetActive(false);
        disconnectElements.SetActive(true);
    }

    public void OnJoinButtonClick()
    {
        isHosting = false;
        networkManager.networkAddress = ipAddressField.text;
        networkManager.StartClient();

        connectElements.SetActive(false);
        disconnectElements.SetActive(true);
    }

    public void OnDisconnectButtonClick()
    {
        if(isHosting)
        {
            networkManager.StopHost();
        }
        else
        {
            networkManager.StopClient();
        }

        disconnectElements.SetActive(false);
        connectElements.SetActive(true);
    }
}
