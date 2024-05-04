using UnityEngine.InputSystem;
using UnityEngine;

public class Radish : MonoBehaviour, ILearnable
{
    // Radishes heal, so we need a ref to player HP
    [SerializeField] private HebeHP playerHealth;
    
    [SerializeField] int _radishCount = 2;
    // rep counter is used to track when the player gets a new radish
    [SerializeField] int _radishRepCounter = 0;
    [SerializeField] int _healAmount = 4;

    void Awake ()
    {
        // on awake, get reference to player HP
        playerHealth = gameObject.GetComponent<HebeHP>();
    }

    // Called on activation
    public void Activate()
    {
        UpdateUI();

    }

    private void UpdateUI()
    {
        // UI code goes here
    }

    // Called by Controller Input
    private void OnRadish()
    {
        if (_radishCount > 0)
        {
            _radishCount -= 1;
            playerHealth?.HealDamage(_healAmount);
            if (_radishRepCounter >= 10){
                ReplenishRadish();
            }
        }
    }

    // Restores a radish
    private void ReplenishRadish()
    {
        _radishCount =+ 1;
        _radishRepCounter = 0;
    }

    // Called to restore radishes 
    public void CountHits()
    {
        _radishRepCounter += 1;
        if (_radishRepCounter >= 10) {
            ReplenishRadish();
        }
    }


}
