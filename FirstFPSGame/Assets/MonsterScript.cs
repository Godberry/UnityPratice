﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    private Animator animator;
    private float MinamunHitPeriod = 1f;
    private float HitCounter = 0; 
    public float CurrentHP = 100;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
    public void Hit (float value)
    {
        if (HitCounter <= 0)
        {
            HitCounter = MinamunHitPeriod;
            CurrentHP -= value;

            animator.SetFloat("HP", CurrentHP);
            animator.SetTrigger("Hit");

            if (CurrentHP <= 0)
            {
                BuryTheBody();
            }
        }
    }

    void BuryTheBody ()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Collider>().enabled = false;
        this.transform.DOMoveY(-0.8f, 1f).SetRelative(true).SetDelay(1).OnComplete(() =>
        {
            this.transform.DOMoveY(-0.8f, 1f).SetRelative(true).SetDelay(3).OnComplete(() =>
           {
               GameObject.Destroy(this);
           });

        });
    }

	// Update is called once per frame
	void Update () {
		if (CurrentHP > 0 && HitCounter > 0)
        {
            HitCounter -= Time.deltaTime;
        }
	}
}
