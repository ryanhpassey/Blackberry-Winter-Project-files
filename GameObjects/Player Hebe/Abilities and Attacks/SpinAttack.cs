using UnityEngine;
using UnityEngine.UI;

public class SpinAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private float speed = .1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Slider cooldownSlider;
    private float CooldownEnd;
    private Vector2 moveDirection;

    private void OnStart(){
        cooldownSlider.maxValue = cooldown;
    }

    private void OnEnable(){
        animator.Play("Hebe_SpinAttack");
        CooldownEnd = Time.time + cooldown;
    }

    private void Update(){
        if (Time.time >= CooldownEnd){
            cooldownSlider.value = 0;
            this.enabled = false;
        }
        else{
            rb.MovePosition(rb.position + (moveDirection * speed));
            cooldownSlider.value = CooldownEnd - Time.time;
        }
    }

    public void SetDirection(FacingDirection direction){
        TransformRotater.Aim(direction);
    }
}
