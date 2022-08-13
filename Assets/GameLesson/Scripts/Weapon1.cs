using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] Transform muzzle;
    [SerializeField] float thrust = 3.0f;
    [SerializeField] float fireRate = 1.0f;
    private Animator playerAnim;
    private float lastTimeFire = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GameObject
            .FindGameObjectWithTag("Player")
            .GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        bool isAllowFire = Time.time > lastTimeFire + fireRate;
        if (Input.GetButton("Fire1"))
        {
            if (isAllowFire)
            {
                lastTimeFire = Time.time;
                playerAnim.SetBool("IsFiring", true);
                GameObject bulletClone = Instantiate(bulletPrefabs, muzzle.position, Quaternion.identity);
                Bullet1 bulletData = bulletClone.GetComponent<Bullet1>();
                if (bulletData.Rb != null)
                {
                    print("Rigid");
                    bulletData.Rb.AddForce(Vector3.forward * thrust, ForceMode.Impulse);
                }
                

                Destroy(bulletClone, 0.3f);
            }
        }
        else
        {
            playerAnim.SetBool("IsFiring", false);
        }
    }
}
