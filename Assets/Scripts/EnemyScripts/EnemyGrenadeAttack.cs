using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrenadeAttack : MonoBehaviour
{
    public GameObject _Enemy;
    public MoveEnemy foundPlayer;
    public EnemyGrenade _grenade;
    public Transform launchingPlace;
    public float launchingForce = 16;
    public float damage = 40;
    public float cooldown = 2f;

    private float grenadeTimer = 0;
    private bool isLaunched = false;

    void Update()
    {
        EnemyAttackControll();
    }

    private void EnemyAttackControll()
    {
        if (launchingPlace && !isLaunched && foundPlayer._foundPlayer == true)
        {
            isLaunched = true;

            EnemyGrenade objGrenade = Instantiate(_grenade, launchingPlace.position, transform.rotation) as EnemyGrenade;
            Rigidbody rbGrenade = objGrenade.GetComponent<Rigidbody>();
            if (_Enemy.transform.localScale.x > 0)
            {
                rbGrenade.AddForce(_Enemy.transform.forward * (launchingForce), ForceMode.Impulse);
            }
            else if (_Enemy.transform.localScale.x < 0)
            {
                rbGrenade.AddForce(_Enemy.transform.forward * -(launchingForce), ForceMode.Impulse);
            }
        }


        if (isLaunched)
        {
            grenadeTimer += Time.deltaTime;
        }
        if (grenadeTimer >= cooldown)
        {
            isLaunched = false;
            grenadeTimer = 0;
        }
    }
}
