using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour, ILearnable
{
    // reference to player health
    [SerializeField] private HebeHP playerHealth;
    [SerializeField] int _reviveCount = 2;
    [SerializeField] int _healthGain = 5;

    void Awake ()
    {
        // on awake, get reference to player HP
        playerHealth = gameObject.GetComponent<HebeHP>();
    }

    // Use revive is called by Hebe HP when health reaches 0
    void OnEnable(){
        HebeHP.OnRevive += UseRevive;
    }

    void OnDisable(){
        HebeHP.OnRevive -= UseRevive;
    }

    public void Activate()
    {
        // UI Code
    }

    private void UseRevive()
    {
        if (_reviveCount > 0)
        {
            _reviveCount -= 1;
            playerHealth.HealDamage(_healthGain);
        }
        

    }
}
