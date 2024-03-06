using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject _character;
    private string healthBarID = "Health";
    private Health _characterHealth;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _characterHealth = _character.GetComponent<Health>();
        healthBar = GetHealthBarID(_character);
        
        if (healthBar != null)
        {
            healthBar.fillAmount = 1f;
        }
        else
        {
            Debug.LogError("Health bar not found for enemy: " + _character.name);
        }
        

        //_characterHealth = _character.GetComponent<Health>();

        //healthBar = GetHealthBarID();

        //healthBar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            float currentHealth = _characterHealth.CurrentHealth;
            float maxHealth = _characterHealth.MaxHealth;
            healthBar.fillAmount = currentHealth / maxHealth;
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
