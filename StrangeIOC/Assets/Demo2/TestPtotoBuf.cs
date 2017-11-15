using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;
public class TestPtotoBuf : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //User user = new User();
        //user.ID = 100;
        //user.Username = "sl";
        //user.Password = "1111";
        //user.Level = 5;
        //user.Type = UserType.Master;

        //using (var fs = File.Create(Application.dataPath + "/user.bin"))
        //{
        //    Serializer.Serialize<User>(fs, user);
        //}

        User user = null;
        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
           user = Serializer.Deserialize<User>(fs);
        }
        print(user.ID);
        print(user.Username);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
