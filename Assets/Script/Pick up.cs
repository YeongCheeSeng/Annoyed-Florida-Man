using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    //public GameObject Weapon;

    public GameObject[] PickUpFeedbacks;

    public LayerMask TargetLayerMask;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col + " dectected");

        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        WeaponHandler _weaponHandler = col.GetComponent<WeaponHandler>();
        //Health _health = col.GetComponent<Health>();

        //if (_health.CurrentHealth == _health.MaxHealth)
        //    return;

        //if (_weaponHandler == null)
        //    return;

        //_weaponHandler.EquipWeapon(Weapon);

        PickedUp(col);

        Destroy(this.gameObject);

        foreach (var feedback in PickUpFeedbacks)
        {
            GameObject PickUpFeedback = GameObject.Instantiate(feedback, transform.position, transform.rotation);
            Destroy(PickUpFeedback, 1f);
        }
    }

    protected virtual void PickedUp(Collider2D col)
    {

    }
}

