using UnityEngine;
using System.Collections;

public class BethSwordSwipe : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Bethrb, playerPosition;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float speed = .25f;
    [SerializeField] private float stepDistance = 3;

    public void StepTowards(){
        Vector2 destination = Vector2.MoveTowards(Bethrb.position, playerPosition.position, stepDistance);

        StartCoroutine(TakeStep(destination));
    }

    private IEnumerator TakeStep(Vector2 destination){
        while (Bethrb.position != destination){
            Bethrb.MovePosition(Vector2.MoveTowards(Bethrb.position, destination, speed));
            yield return null;
        }
    }

    public void RotateAttack(){
        Vector2 direction = Bethrb.position - playerPosition.position;
        TransformRotater.RotateAttack(direction, attackPoint);
    }
}
