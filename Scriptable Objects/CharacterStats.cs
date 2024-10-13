using UnityEngine;

[CreateAssetMenu]
public class CharacterStats : ScriptableObject
{
    public float Speed;
    public float DashSpeed;
    public int Attack;
    public FacingDirection CurrentDirectionFacing;
}
