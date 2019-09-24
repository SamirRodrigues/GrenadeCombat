using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAttack : MonoBehaviour
{
    public GameObject _Player;
    public AllyGrenade _grenade;
    public Transform launchingPlace;
    public float launchingForce = 5;
    public float damage = 10;
    public float munition = 10;
    public float cooldown = 0.5f;
    public bool infinityAmmo = false;

    private float grenadeTimer = 0;
    private bool isLaunched = false;

    void Update()
    {
        AttackControll();
    }

    private void AttackControll()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            infinityAmmo = !infinityAmmo;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (infinityAmmo == true && munition <= 1)
            {
                munition += 10;
            }

            if (launchingPlace && munition >= 1 && !isLaunched)
            {
                munition -= 1;
                isLaunched = true;

                AllyGrenade objGrenade = Instantiate(_grenade, launchingPlace.position, transform.rotation) as AllyGrenade;
                Rigidbody rbGrenade = objGrenade.GetComponent<Rigidbody>();
                if (_Player.transform.localScale.x > 0)
                {
                    Vector3 temp = _Player.transform.right;
                    temp.Set(_Player.transform.right.x, _Player.transform.up.y, 0);
                    rbGrenade.AddForce(temp * (launchingForce), ForceMode.Impulse);
                }
                else if (_Player.transform.localScale.x < 0)
                {
                    Vector3 temp = _Player.transform.right;
                    temp.Set(_Player.transform.right.x * _Player.transform.localScale.x, _Player.transform.up.y, 0);
                    rbGrenade.AddForce(temp * (launchingForce), ForceMode.Impulse);
                }

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
