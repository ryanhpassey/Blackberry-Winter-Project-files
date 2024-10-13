using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Script attached to the camera
    [SerializeField] private float duration = 5f;

    private void OnEnable(){
        HebeHP.OnPlayerDeath += SlowTimeGradualRecoverCall;
    }

    private void OnDisable(){
        HebeHP.OnPlayerDeath -= SlowTimeGradualRecoverCall;
    }

    private void SlowTimeGradualRecoverCall(){
        StartCoroutine(SlowTimeGradualRecover(duration));
    }

    private IEnumerator SlowTimeGradualRecover(float seconds){
        Time.timeScale = .1f;

        float elapsedTime = 0f;
        while (elapsedTime < seconds){
            elapsedTime += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(.1f, 1f, elapsedTime / seconds);
            yield return null;
        }

        Time.timeScale = 1f;
    }
}
