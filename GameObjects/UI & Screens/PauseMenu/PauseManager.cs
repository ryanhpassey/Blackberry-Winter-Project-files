using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerInput playerInput;

    // Called by PlayerInput.
    private void OnPause()
    {
        //Activate pause screen, set timescale to 0, then change controller mapping
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        playerInput.SwitchCurrentActionMap("Paused");
    }

    // Called by PlayerInput.
    public void OnUnpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        playerInput.SwitchCurrentActionMap("Unpaused");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }


}
