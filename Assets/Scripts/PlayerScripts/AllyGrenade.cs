using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AllyGrenade : MonoBehaviour
{
    public float blastRadius = 1;
    public GameObject explosionParticle;
    public GrenadeAttack Ally;

    
    private bool isExploded = false;

    private void Awake()
    {
        Ally =  GameObject.FindGameObjectWithTag("Player").GetComponent<GrenadeAttack>();
    }

    void Update()
    {
        if (isExploded == true)
        {
            Explode(transform.position, blastRadius);
        }
        
    }

    void Explode(Vector3 blastCenter, float radius)
    {
        Collider[] hitedColliders = Physics.OverlapSphere(blastCenter, radius);
        for (int i = 0; i < hitedColliders.Length; i++)
        {
            CharacterStats aux = hitedColliders[i].GetComponent<CharacterStats>();
            if (aux) // Só aplica a ação se o objeto tiver CharacterStats
            {
                aux.TakeDamage(Ally.damage);                
            }
        }

        if (explosionParticle)
        {
            GameObject particle = Instantiate(explosionParticle, transform.position, transform.rotation) as GameObject;
            Destroy(particle /*O que vai destruir*/, 0.5f /*Tempo de espera*/);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        isExploded = true;
    }
}
