using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float firerate;    
    [SerializeField] Transform muzzle;
    [SerializeField] Vector3 muzzleOffset;
    private float lastTimeFire = 0.0f;

    public void Fire()
    {
        if (Time.time > lastTimeFire + firerate)
        {
            lastTimeFire = Time.time;
            GameObject bulletClone = Instantiate(bulletPrefab, muzzle.position + muzzleOffset, Quaternion.identity);
            Bullet bulletData = bulletClone.GetComponent<Bullet>();
            bulletData.Rigidbody.AddForce(Vector3.forward * bulletData.Speed, ForceMode.Impulse);
            Destroy(bulletClone, 0.2f);
        }        
    }
}
