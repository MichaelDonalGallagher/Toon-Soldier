using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Range(0.1f,1.5f)]
    public float fireRate = .1f;
    [Range(1, 10)]
    public float damage = 1;
    public Transform firePoint;
    private LineRenderer laserLineRenderer;
    public float laserWidth = .01f;

    void fireGun()
    {
        RaycastHit rayCastHit;
        Ray ray = new Ray(firePoint.position, firePoint.forward*100);

        laserLineRenderer.SetPosition(0, firePoint.position);
        
        IEnumerator coroutine = ActivateLaser();
        StartCoroutine(coroutine);
        
        //Debug.DrawRay(firePoint.position,firePoint.forward*100, Color.red,2f);
        if (Physics.Raycast(ray,out rayCastHit, 10f))
        {
            print(rayCastHit.transform.name);
            rayCastHit.transform.GetComponent<Health>().takeDamage();
            laserLineRenderer.SetPosition(1,rayCastHit.point);
        }
        else
        {
            laserLineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 10);
        }
    }
    private void Start()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireGun();
        }
    }

    IEnumerator ActivateLaser()
    {
        laserLineRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        laserLineRenderer.enabled = false;
    }
}
