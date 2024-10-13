using UnityEngine;

public class HebeParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem IceShatterParticles;

    public void OneIceShatter(){
        IceShatterParticles.Play();
    }
}

