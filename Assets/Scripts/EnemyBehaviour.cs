using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private DateTime lastShoot;
    private double intervalShoot;
    private DateTime lastMove;
    private double intervalMove;
    private Animator mAnim;
    private Boolean isDead;

    public GameObject bulletPrefab;
    public float cubeExplosionSize = 0.1f;
    public int explosionForce = 120;
    public int explosionRadius = 10;
    public float explosionUpward = 10f;
    public GameObject rightArm;

    void Start()
    {
        this.intervalShoot = UnityEngine.Random.Range(1, 5);
        this.lastShoot = DateTime.Now;
        mAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (GameObject.Find("Vie") && !isDead)
        {
            this.Shoot();
        }
            
        
        if (Vector3.Distance(this.transform.position, Camera.main.transform.position) > 3)
        {
            this.MovesToCam();
        }
        else mAnim.Play("Idle");
        this.transform.LookAt(Camera.main.transform);
    }

    void Shoot()
    {
        if (DateTime.Now >= lastShoot.AddSeconds(this.intervalShoot))
        {
            //mAnim.Play("Idle");
            RaiseArm();
            var bullet = Instantiate(bulletPrefab, rightArm.transform.position, Quaternion.identity);
            this.lastShoot = DateTime.Now;
            DownArm();
        }
    }


    private IEnumerator RaiseArm()
    {
        mAnim.SetTrigger("RaiseRightArm");
        yield return new WaitForSeconds(mAnim.GetCurrentAnimatorStateInfo(0).length + mAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    private IEnumerator DownArm()
    {
        mAnim.SetTrigger("DownRightArm");
        yield return new WaitForSeconds(mAnim.GetCurrentAnimatorStateInfo(0).length + mAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    void MovesToCam()
    {
        Vector3 camPos = Camera.main.transform.position;
        Debug.Log(camPos - this.transform.position);
        Vector3 nextPos = camPos - this.transform.position;
        if (camPos - this.transform.position != new Vector3(0, 0, 0))
        {
            if (mAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) mAnim.Play("EnnemyWalkRight");
            Vector3 movementVector = (camPos - this.transform.position).normalized;

            this.transform.position += movementVector * Time.deltaTime * 1.0f;
        }
        else
        {
            mAnim.Play("Idle");
        }
    }

    public void explodeChild(GameObject firstHit, Collider bullet)
    {
        mAnim.Play("Idle");
        this.isDead = true;
        Camera.main.gameObject.GetComponent<CameraBehaviour>().enemyKilled();
        EnemyExplodeBehavior[] cubes = gameObject.GetComponentsInChildren<EnemyExplodeBehavior>();
        foreach (EnemyExplodeBehavior cube in cubes)
        {
            if (firstHit.name != cube.name) cube.explode(bullet);
        }
    }
}
