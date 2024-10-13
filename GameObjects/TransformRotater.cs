using UnityEngine;

public static class TransformRotater
{
    public static FacingDirection DecideRotation(Vector2 direction){
        double pivotRelationDeadZone = .5;
        // if target is to the right
        if (direction.x > pivotRelationDeadZone){
            if (direction.y > pivotRelationDeadZone){
                return FacingDirection.UpRight;
            }
            else if (direction.y < -1 * pivotRelationDeadZone){
                return FacingDirection.DownRight;
            }
            else {
                return FacingDirection.Right;
            }
        } // if target is to the left
        else if (direction.x < -1 * pivotRelationDeadZone){
            if (direction.y > pivotRelationDeadZone){
                return FacingDirection.UpLeft;
            }
            else if (direction.y < -1 * pivotRelationDeadZone){
                return FacingDirection.DownLeft;
            }
            else {
                return FacingDirection.Left;
            }
        } // if target's x pos is close to yours
        else {
            if (direction.y > .1){
                return FacingDirection.Up;
            }
            else if(direction.y < -.1){
                return FacingDirection.Down;
            }
            else{
                return FacingDirection.Center;
            }
        }
    }

    public static void RotateAttack(Vector2 inputVector, Transform transform){
        FacingDirection direction = DecideRotation(inputVector);
        switch (direction){
            case FacingDirection.Up:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                break;
            case FacingDirection.UpRight:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,-45));
                break;
            case FacingDirection.Right:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
                break;
            case FacingDirection.DownRight:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,-135));
                break;
            case FacingDirection.Down:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
                break;
            case FacingDirection.DownLeft:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,135));
                break;
            case FacingDirection.Left:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                break;
            case FacingDirection.UpLeft:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,45));
                break; 
        }
    }

    public static Vector2 Aim(FacingDirection direction){
        switch (direction)
        {
            case FacingDirection.Up:
                return Vector2.up;
            case FacingDirection.UpRight:
                return new Vector2(0.7071f,0.7071f);
            case FacingDirection.Right:
                return Vector2.right;
            case FacingDirection.DownRight:
                return new Vector2(0.7071f,-0.7071f);
            case FacingDirection.Down:
                return Vector2.down;
            case FacingDirection.DownLeft:
                return new Vector2(-0.7071f,-0.7071f);
            case FacingDirection.Left:
                return Vector2.left;
            default:
                return new Vector2(-0.7071f,0.7071f);
        }
    }
}

