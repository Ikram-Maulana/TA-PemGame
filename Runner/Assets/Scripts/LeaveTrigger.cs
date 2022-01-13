using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            LevelGenerator.sharedInstance.AddNewBlock();

            LevelGenerator.sharedInstance.RemoveOldBlock();
        }
    }
}
