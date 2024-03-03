using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //public GameObject _character;

    private string healthBarID = "Health";
    private Health[] _characterHealth;
    private Image[] healthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] _character = GameObject.FindGameObjectsWithTag("Enemy");

        _characterHealth = new Health[_character.Length];
        healthBar = new Image[_character.Length];

        for (int i = 0; i < _character.Length; i++)
        {
            _characterHealth[i] = _character[i].GetComponent<Health>();
            healthBar[i] = GetHealthBarID(_character[i]);
        }

        for (int i = 0; i < healthBar.Length; i++)
        {
            if (healthBar[i] != null)
            {
                healthBar[i].fillAmount = 1f;
            }
            else
            {
                Debug.LogError("Health bar not found for enemy: " + _character[i].name);
            }
        }

        //_characterHealth = _character.GetComponent<Health>();

        //healthBar = GetHealthBarID();

        //healthBar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _characterHealth.Length; i++)
        {
            if (healthBar[i] != null)
            {
                float currentHealth = _characterHealth[i].CurrentHealth;
                float maxHealth = _characterHealth[i].MaxHealth;
                healthBar[i].fillAmount = currentHealth / maxHealth;
            }
        }

        //if (healthBar == null || _character == null)
        //{
        //    healthBar.fillAmount = 0;
        //    return;
        //}

        //float _characterCurrentHealth = _characterHealth.CurrentHealth / _characterHealth.MaxHealth;
        //healthBar.fillAmount = _characterCurrentHealth;
    }

    private Image GetHealthBarID(GameObject _character) 
    {
        Image[] images = _character.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            if (image.name == healthBarID)
                return image;
        }

        return null;
    }
}
