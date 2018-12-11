﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Kino;

public class Player : MonoBehaviour
{
	FirstPersonController firstPerson;
	public DigitalGlitch glitch;
	public float health = 100;
	public float regen = 7;
	public float regenDelay = 3;
	public float regenTimer;
	// Start is called before the first frame update
	void Start()
	{
		firstPerson = GetComponent<FirstPersonController>();
		regenTimer = regenDelay;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Switch"))
		{
			firstPerson.m_MouseLook.SetCursorLock(!firstPerson.m_MouseLook.lockCursor);
			firstPerson.canLook = !firstPerson.canLook;
		}
		glitch._intensity = Mathf.Clamp(1 - (health / 100f), 0, 1);
		if (health < 100)
		{
			regenTimer -= Time.deltaTime;
			if (regenTimer < 0)
			{
				health += regen * Time.deltaTime;
			}
		}
	}

	public void damage(float damage)
	{
		regenTimer = regenDelay;
		health -= damage;
	}

	void Death()
	{

	}
}
