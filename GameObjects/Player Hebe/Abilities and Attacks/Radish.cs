using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Radish : MonoBehaviour, ILearnable
{
    // Radishes heal, so we need a ref to player HP
    [SerializeField] private HebeHP playerHealth;
    
    // Sprites to be turned on / off as radishes are used
    private Image _radishSprite1;
    private Image _radishSprite2;

    [SerializeField] int _radishCount = 2;
    // rep counter is used to track when the player gets a new radish
    [SerializeField] int _hits = 0;
    [SerializeField] int _hitsNeeded = 20;
    [SerializeField] int _healAmount = 4;

    void Start ()
    {
        // on start, get reference to player HP
        playerHealth = gameObject.GetComponent<HebeHP>();
        _radishSprite1 = GameObject.Find("Radish Sprite 1").GetComponent<Image>();
        _radishSprite2 = GameObject.Find("Radish Sprite 2").GetComponent<Image>();
        UpdateUI();
    }

    void OnEnable(){
        HebeAttackScript.OnDamageDealt += CountHits;
    }

    void OnDisable(){
        HebeAttackScript.OnDamageDealt -= CountHits;
    }

    // Called on activation
    public void Activate()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_radishCount == 2)
        {
            _radishSprite1.enabled = true;
            _radishSprite2.enabled = true;
        }
        else if (_radishCount == 1){
            _radishSprite1.enabled = true;
            _radishSprite2.enabled = false;
        }
        else{
            _radishSprite1.enabled = false;
            _radishSprite2.enabled = false;
        }
        
    }

    // Called by Controller Input
    private void OnRadish()
    {
        if (_radishCount > 0)
        {
            _radishCount -= 1;
            playerHealth?.HealDamage(_healAmount);
            UpdateUI();
        }
    }

    // Restores a radish
    private void ReplenishRadish()
    {
        _radishCount += 1;
        _hits = 0;
        UpdateUI();
    }

    // Called to restore radishes 
    public void CountHits()
    {
        if (_radishCount < 2){
            _hits += 1;
            if (_hits >= _hitsNeeded) {
                ReplenishRadish();
            }
        }
    }
}
