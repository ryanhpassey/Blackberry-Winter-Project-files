using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beth_ProjectileManager : MonoBehaviour
{
    [SerializeField] private GroundIceManager LingeringGroundIce;
    [SerializeField] private GameObject Snowman;
    [SerializeField] private GameObject Snowflake1;
    [SerializeField] private GameObject Snowflake2;
    [SerializeField] private BethSwordSwipe SwordSwipe;
    private bool SnowflakeTracker;

    public void SpawnGroundIce(){
        LingeringGroundIce.gameObject.SetActive(true);
    }

    public void SpawnSnowman(){
        Snowman.gameObject.SetActive(true);
    }

    //Spawn snowflake, but alternate between them
    public void SpawnSnowflake(){
        if (SnowflakeTracker){
            Snowflake1.gameObject.SetActive(true);
        }
        else{
            Snowflake2.gameObject.SetActive(true);
        }
        SnowflakeTracker = !SnowflakeTracker;
    }

    public void StepTowards(){
        SwordSwipe.RotateAttack();
        SwordSwipe.StepTowards();
    }
}
