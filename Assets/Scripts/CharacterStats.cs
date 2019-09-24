using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public float life = 100;
    public Slider lifeBar;

    private void Start()
    {
        lifeBar.minValue = 0;
        lifeBar.maxValue = life;
        lifeBar.value = life;
    }

    void Update()
    {
        LifeControl();
    }

    private void LifeControl()
    {
        if (lifeBar.value >= life)
        {
            lifeBar.value = life;
        }
        else if (lifeBar.value <= 0)
        {
            lifeBar.value = lifeBar.minValue;
        }

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;
        Debug.Log("Life:" + life + " - "+ tag + " take damage = " + _damage);        
    }
}
