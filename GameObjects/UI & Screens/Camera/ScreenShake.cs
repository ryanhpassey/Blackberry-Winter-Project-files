using UnityEngine;
using System.Collections;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float duration = 1f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin cameraShake;

    public delegate IEnumerator ShakeScreenDelegate();
    public static ShakeScreenDelegate onShakeScreen;

    void Start(){
        cameraShake = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    void OnEnable() {
        onShakeScreen += ShakeScreen;
    }

    void OnDisable() {
        onShakeScreen -= ShakeScreen;
    }

    public IEnumerator ShakeScreen(){
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            cameraShake.m_AmplitudeGain = curve.Evaluate(elapsedTime / duration);
            yield return null;
        }

        cameraShake.m_AmplitudeGain = 0f;
    }
    
}
