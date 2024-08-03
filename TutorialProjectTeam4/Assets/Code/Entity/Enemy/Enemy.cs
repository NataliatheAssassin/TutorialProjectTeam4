using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected Player player { get => FindObjectOfType<Player>(); }

    [SerializeField] protected GameObject attack;
}
