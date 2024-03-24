using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject[] PickUpFeedbacks; 

    public LayerMask TargetLayerMask;
    public LayerMask IgnoreLayerMask;

    private string weaponTag = "Weapon";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (((IgnoreLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0) && Weapon != null)
        {
            DeactivateWeaponWithTag(weaponTag);
            Weapon.SetActive(true);
            SpawnFeedback();
            Destroy(this.gameObject);           
        }
    }

    void SpawnFeedback()
    {
        foreach (var feedback in PickUpFeedbacks)
        {
            GameObject FeedbackClone = GameObject.Instantiate(feedback, transform.position, transform.rotation);
            Destroy(FeedbackClone, 1f);
        }
    }

    void DeactivateWeaponWithTag(string tag)
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag(tag);

        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }
    }
}
