using UnityEngine;

public class IceHebeManager : MonoBehaviour
{
    [SerializeField] Transform PlayerPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float distanceMultiplyer = 5;
    [SerializeField] float lastRefresh, vectorRefreshRate = .5f;
    [SerializeField] float speed = 6;
    [SerializeField] Animator animator;
    private Vector2 direction;

    private void OnEnable(){
        rb.position = GetSpawnPosition(PlayerPosition.position);
        lastRefresh = vectorRefreshRate;
    }

    private void FixedUpdate(){
        if (lastRefresh >= vectorRefreshRate){
            lastRefresh = 0f;
            direction = GetDestination(rb.position, PlayerPosition.position);
        }
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        lastRefresh += Time.fixedDeltaTime;
    }

    //Returns the spawn position by normalizing a randomly generated vector
    private Vector2 GetSpawnPosition(Vector3 spawnPivot){
        // I used 50 to minimize the chance of getting a vector with a magnitude less than 1
        Vector3 spawnPoint = new(Random.Range(-50,50), Random.Range(-50,50), 0);
        return spawnPivot + (spawnPoint.normalized * distanceMultiplyer);
    }

    private Vector2 GetDestination(Vector3 currentPosition, Vector3 playerPosition){
        return (playerPosition - currentPosition).normalized;
    }

    private void OnTriggerEnter2D(){
        gameObject.SetActive(false);
    }

}
