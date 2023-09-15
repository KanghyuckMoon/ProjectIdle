using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.PlayerProfile.AddExp(1);
            
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.PlayerProfile.AddExp(-1);
        }
    }
}
