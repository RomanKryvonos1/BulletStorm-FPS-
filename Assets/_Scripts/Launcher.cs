using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using WebSocketSharp;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] TMP_Text errorText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log("Connecting to master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Menumanager.Instance.Openmenu("TitleScreen");
        Debug.Log("Joined lobby");
    }

    public void Createroom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        Menumanager.Instance.Openmenu("LoadingScreen");
    }

    public override void OnJoinedRoom()
    {
        Menumanager.Instance.Openmenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room creation failed" + message;
        Menumanager.Instance.Openmenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Menumanager.Instance.Openmenu("LoadingScreen");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        Menumanager.Instance.Openmenu("LoadingScreen");
    }

    public override void OnLeftRoom()
    {
        Menumanager.Instance.Openmenu("TitleScreen");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

}
