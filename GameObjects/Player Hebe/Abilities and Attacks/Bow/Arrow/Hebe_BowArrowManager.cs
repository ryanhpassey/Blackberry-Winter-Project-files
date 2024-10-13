using UnityEngine;

public class Hebe_BowArrowManager : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private Transform SpawnPosition, ExplosionPosition;
    private Vector2 targetDirection;
    [SerializeField] private float Speed = 5;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator explosionAnimator;
    private FacingDirection playerFacingDirection = FacingDirection.Up;
    private string startAnimation = "Bow_StartAnimation";
    private string destroyedAnimation = "Bow_DestroyedAnimation";

    private void FixedUpdate(){
        rb.MovePosition(rb.position + targetDirection * Speed * Time.fixedDeltaTime);
    }

    private void OnEnable() {
        gameObject.transform.position = SpawnPosition.position;
        SetDirection(playerFacingDirection);
        Animator.Play(startAnimation);
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag != "Freeze" && col.tag != "Player"){
            // # play destroy animation
            SpawnExplosion();
        }
    }

    private void SetDirection(FacingDirection facingDirection){
        targetDirection = TransformRotater.Aim(facingDirection);
    }

    public void SetFacingDirection(FacingDirection direction){
        playerFacingDirection = direction;
    }

    public void SpawnExplosion(){
        Animator.Play(destroyedAnimation);
        ExplosionPosition.position = rb.position;
        explosionAnimator.Play("Hebe_ArrowExplosion");
        Debug.Log("Play now");
        this.enabled = false;
    }
}
