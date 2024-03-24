using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public float DropChance = 10f;

    public GameObject[] RandomLoots;

    private Health _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = GetComponent<Health>();

        if (_health == null)
            return;

        _health.OnDeath += DropLoot;
    }

    // Update is called once per frame
    private void DropLoot()
    {
        float chance = Random.Range(0, 100);

        if (chance > DropChance)
            return;

        int selectedLoot = Random.Range(0, RandomLoots.Length);

        if (RandomLoots[selectedLoot] == null)
            return;

        GameObject Loot = GameObject.Instantiate(RandomLoots[selectedLoot], transform.position, transform.rotation);
        Loot.SetActive(true);
        Destroy(Loot, 10f);
    }
}
