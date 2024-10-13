using UnityEngine;

public class Attack_Projectile_Manager : MonoBehaviour
{
    [SerializeField] private Transform JabPivot, SpinAttackPosition;
    [SerializeField] private Transform HebeTransform;
    [SerializeField] private SpinAttack SpinAttack;
    [SerializeField] private Hebe_BowArrowManager HebeBow;

    public void OnJabEnable(){
        JabPivot.position = HebeTransform.position;
    }

    public void OnSpinAttack(FacingDirection direction){
        if (SpinAttack.enabled == false){
            SpinAttackPosition.position = HebeTransform.position;
            SpinAttackPosition.rotation = Quaternion.Euler(RotateAttack(direction));
            SpinAttack.enabled = true;
            SpinAttack.SetDirection(direction);
        }
    }

    public void OnArrow(FacingDirection direction){
        if(HebeBow.enabled == false){
            HebeBow.SetFacingDirection(direction);
            HebeBow.enabled = true;
        }
        else{
            HebeBow.SpawnExplosion();
        }
    }

    private Vector3 RotateAttack(FacingDirection attackDirection)
    {
        switch (attackDirection)
        {
            case FacingDirection.Up:
                return new Vector3(0,0,0);
            case FacingDirection.UpRight:
                return new Vector3(0,0,-45);
            case FacingDirection.Right:
                return new Vector3(0,0,-90);
            case FacingDirection.DownRight:
                return new Vector3(0,0,-135);
            case FacingDirection.Down:
                return new Vector3(0,0,180);
            case FacingDirection.DownLeft:
                return new Vector3(0,0,135);
            case FacingDirection.Left:
               return new Vector3(0,0,90);
            default:
                return new Vector3(0,0,45);
        }
    }
}
