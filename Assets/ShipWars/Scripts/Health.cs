using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    protected int hitPoints = 10;

    public void Damage(int damageCaused)
    {
        hitPoints -= damageCaused;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
