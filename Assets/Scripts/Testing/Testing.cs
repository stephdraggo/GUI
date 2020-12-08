using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GUI1.PlayerControl player;
    void Start()
    {
        player = FindObjectOfType<GUI1.PlayerControl>();
    }

    void Update()
    {
        #region damage player with X
        if (Input.GetKeyDown(KeyCode.X))
        {
            player.Damaged(10);
        }
        #endregion
    }
}
