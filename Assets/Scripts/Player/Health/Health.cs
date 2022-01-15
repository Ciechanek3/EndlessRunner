using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHp;

    private int currentHp;

    public event Action OnPlayerDead;

    private bool IsDead { get => currentHp <= 0; }

    public int CurrentHp { get => CurrentHp; }

    private void Start()
    {
        currentHp = startingHp;
    }

    public void LoseHp()
    {
        currentHp--;
        if (IsDead)
        {
            OnPlayerDead?.Invoke();
        }
    }

    public void GainHealth()
    {
        if (currentHp < 5)
        {
            currentHp++;
        }
    }
}
