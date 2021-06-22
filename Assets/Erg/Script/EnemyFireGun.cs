using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireGun : SimpleShoot
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject arrel;
    public Transform barrelLocationOverride;
    public Transform FirePoint;

    float timer;
    float DelayTimeShoot = 2.0f;
    public override void Start()
    {
        if (barrelLocationOverride == null)
            barrelLocationOverride = transform;
     
    }

    // Update is called once per frame
    protected override void Shoot()
    {
        //enemy.transform.LookAt(FirePoint.position);
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocationOverride.position, barrelLocationOverride.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocationOverride.position, barrelLocationOverride.rotation).GetComponent<Rigidbody>().AddForce(barrelLocationOverride.forward * shotPower);
        enemy.GetComponent<ActionsWarrior>().Attack();
        
    }

    //private IEnumerator ExecuteAfterTime(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    Shoot();
    //}

    //public void ShootToPlayer(float time)
    //{

    //    StartCoroutine(ExecuteAfterTime(time));
    //}
   

   

    public void AttackTimer()
    {
        timer += Time.deltaTime;
        if (timer > DelayTimeShoot)
        {
            Shoot();
            timer = 0;
        }

    }
}
