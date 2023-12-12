using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : CharacterAIMovementController
{
    public override void Start()
    {
        base.Start();
        SetTarget(FindObjectOfType<Player>().transform);
    }
}
