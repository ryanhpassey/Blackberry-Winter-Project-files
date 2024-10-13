using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float _movementSmoothing = .1f;
    private Vector3 _screenOffset;
    private Vector3 _playerPosition;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        _playerPosition = Vector3.MoveTowards(Player.transform.position, Enemy.transform.position, 5);
        _playerPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, _playerPosition, ref velocity, _movementSmoothing);
    }
}
