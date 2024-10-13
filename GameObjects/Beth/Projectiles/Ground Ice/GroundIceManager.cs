using UnityEngine;

public class GroundIceManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;

    private void OnEnable(){
        gameObject.transform.position = spawnPosition.position + new Vector3(0,-1f, 0);
    }

    public void Disable(){
        gameObject.SetActive(false);
    }

}
