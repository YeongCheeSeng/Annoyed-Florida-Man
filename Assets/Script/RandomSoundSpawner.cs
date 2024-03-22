using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSoundSpawn : MonoBehaviour
{
    public float SpawnChance = 50f;
    public float SpawnInterval;
    public float SoundLifeTime;

    public GameObject[] Feedbacks;
    public GameObject Object;

    private bool _isPlaying;
    private float SpawnCooldown;

    private void Start()
    {
        _isPlaying = false;
        SpawnCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCooldown -= Time.deltaTime;

        if (SpawnCooldown <= 0)
        {
            SpawnCooldown = 0;
        }

        if (Object == null || _isPlaying == true)
        {
            return;
        }

        SpawnFeedback();
    }

    void SpawnFeedback()
    {
        if (SpawnCooldown <= 0) 
        {
            float rollDice = Random.Range(1, 100);

            if (rollDice > SpawnChance)
            {
                SpawnCooldown = SpawnInterval;
                return;
            }

            foreach (var feedback in Feedbacks)
            {
                GameObject EnemySpawnFeedback = GameObject.Instantiate(feedback);
                SpawnCooldown = SpawnInterval;
                Destroy(EnemySpawnFeedback, SoundLifeTime);
            }
        }
    }
}
