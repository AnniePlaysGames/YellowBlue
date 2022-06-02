using CodeBase.StaticData;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _damage;

    public void AttackData(WeaponData data) 
        => _damage = data.damage;
}
