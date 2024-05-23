﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsController2 : MonoBehaviour
{
    [Header("Bullets Actions")]
    public bool gunsActive;
    public int currentBullets;
    public int maxBulletsPerMag = 100;
    public int bulletsLeft = 300;
    public float fireRate = 0.17f;

    [Header("Audio Actions")]
    public AudioClip shotSound;
    public AudioSource barrelSource;
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    [Header("Recoil Actions")]
    public float recoilForce;
    public Transform recoilPosition;

    [Header("Shot Actions")]
    public Vector3 randomRotation = new Vector3(.1f, .1f, .1f);
    public GameObject ShellPrefab;
    public float shellVelocity = 500f;
    public GameObject hitPrefab;
    public int hitDestroyTime = 10;
    public ParticleSystem muzzleFlash;
    public Transform ejectPoint;

    [Header("Barrel Recoil Actions")]
    public Transform recoilBarrelTransform;
    public Vector3 kickBackRecoilBarrel;
    public float kickBackSpeed = 8f;
    public float barrelReturnSpeed = 18f;

    private float fireTimer;
    private Vector3 positionRecoil;
    private Rigidbody rb;

    public float radius = 10.0f;

    public int damage = 10;// 총알 데미지

    private void Start()
    {
        currentBullets = maxBulletsPerMag;
        rb = GetComponent<Rigidbody>();
        fireTimer = fireRate;
    }

    private void Update()
    {
        if (!gunsActive)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && gunsActive && Shop.bullActive)
        {
            Shoot();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

        Debug.DrawRay(ejectPoint.position, ejectPoint.forward * 200);
    }

    private void FixedUpdate()
    {
        if (recoilBarrelTransform)
            Recoil();
    }

    private void Recoil()
    {
        positionRecoil = Vector3.Slerp(positionRecoil, Vector3.zero, barrelReturnSpeed * Time.deltaTime);
        recoilBarrelTransform.localPosition = Vector3.Slerp(recoilBarrelTransform.localPosition, -positionRecoil, kickBackSpeed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (fireTimer < fireRate || currentBullets <= 0)
            return;

        currentBullets--;

        positionRecoil += kickBackRecoilBarrel;

        if (ShellPrefab != null)
        {
            ejectPoint.localEulerAngles = new Vector3(Random.Range(-randomRotation.x, randomRotation.x), Random.Range(-randomRotation.y, randomRotation.y), Random.Range(-randomRotation.z, randomRotation.z));

            GameObject shell = Instantiate(ShellPrefab, ejectPoint.position, ejectPoint.rotation) as GameObject;

            Projectile projectile = shell.GetComponent<Projectile>();
            projectile.hitPrefab = hitPrefab;
            projectile.hitDestroyTime = 10;

            Rigidbody shellBody = shell.GetComponent<Rigidbody>();
            shellBody.AddForce(ejectPoint.forward * shellVelocity, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("탄피 프리팹을 지정하십시오!");
        }

        if (muzzleFlash)
            muzzleFlash.Play();

        barrelSource.pitch = Random.Range(minPitch, maxPitch);
        barrelSource.PlayOneShot(shotSound);

        rb.AddForceAtPosition(recoilPosition.forward * recoilForce, recoilPosition.position, ForceMode.Impulse);

        fireTimer = 0.0f;

        // 총알이 적에게 맞았는지 레이캐스트로 감지합니다.
        RaycastHit hit;
        if (Physics.Raycast(ejectPoint.position, ejectPoint.forward, out hit, Mathf.Infinity))
        {
            Collider[] hitColliders = Physics.OverlapSphere(hit.point, 10.0f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    Enemyhp enemy = hitCollider.GetComponent<Enemyhp>();
                    if (enemy != null)
                    {
                        enemy.TankDamage(damage);
                    }
                }
            }
        }
    }
}