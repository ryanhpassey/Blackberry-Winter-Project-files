using UnityEngine;

public class IceBallManager : MonoBehaviour, IDamageable
{
    Transform iceTransform;

    private void Awake()
    {
        iceTransform = gameObject.GetComponent<Transform>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        gameObject.SetActive(false);
    }

    // Keeps the ice facing up
    void FixedUpdate()
    {
        iceTransform.rotation = Quaternion.identity;
    }
}
