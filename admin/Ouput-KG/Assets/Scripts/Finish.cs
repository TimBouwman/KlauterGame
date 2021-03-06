﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    private float slowDownFector = 0.05f;
    private bool won = false;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!won && (other.gameObject.layer == 10 || other.gameObject.layer == 11))
        {
            if (other.gameObject.layer == 10) Debug.Log("Player 1 wins.");
            else if (other.gameObject.layer == 11)  Debug.Log("Player 2 wins.");
            StartCoroutine(WinEffects(other.transform.position));
            won = true;
        }
    }

    /// <summary>
    /// This slows down time, plays a particle effect and starts a count down to reload the game.
    /// </summary>
    /// <param name="pos">The location where the particle effect is played.</param>
    /// <returns></returns>
    private IEnumerator WinEffects(Vector3 pos)
    {
        Time.timeScale = slowDownFector;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;

        particle.transform.position = pos;
        particle.Play();

        yield return new WaitForSeconds(0.07f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StopCoroutine(WinEffects(Vector3.zero));
    }
}