using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData
{
    public readonly static UserData Instance = new UserData();

    public int USER_ID = 0;
    public string USER_NAME = string.Empty;
    public bool MASTER = true;

}

public class RoomData
{
    public readonly static RoomData Instance = new RoomData();

    public RoomInfo[] roomArray;
}