using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    public GameObject Weapon;

    protected override void PickedUp(Collider2D col)
    {
        WeaponHandler _weaponHandler = col.GetComponent<WeaponHandler>();

        if (_weaponHandler == null)
            return;

        _weaponHandler.EquipWeapon(Weapon);
    }
}
