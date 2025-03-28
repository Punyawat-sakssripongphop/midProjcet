using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public Transform mCameraT;
    private bool isShooting = false;

    public bool isAutoGun = false;
    public float fireRate = 10f;
    private bool isReadyToShoot;
    private float nextFireTime;

    public GameObject gunFxPrefab;
    public float gunFxLifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        isReadyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
        
        if(isShooting && isReadyToShoot)
        {
            PerformShot();
        }

        if(!isReadyToShoot)
        {
            nextFireTime -= Time.deltaTime;
            if(nextFireTime < 0)
            {
                isReadyToShoot = true;
            }
        }
    }

    private void PerformShot()
    {
        isReadyToShoot = false;
        
        RaycastHit hitInfo;
        if(Physics.Raycast(mCameraT.position, mCameraT.forward,out hitInfo))
        {
            Debug.Log($"BaseGun : Fire Hit {hitInfo.collider.name}!");

            GameObject fx = Instantiate(gunFxPrefab, hitInfo.point, Quaternion.FromToRotation(transform.forward, hitInfo.normal));
            Destroy(fx, gunFxLifeTime);
        }

        nextFireTime = 1f / fireRate;
        if(!isAutoGun)
        {
            isShooting = false;
        }
    }
}
