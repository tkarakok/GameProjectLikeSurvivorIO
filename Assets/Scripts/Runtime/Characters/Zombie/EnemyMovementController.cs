using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMovementController : CharacterAIMovementController
{
    [Inject]
    private Player _player;
    
    public override void Start()
    {
        base.Start();
        SetTarget(_player.transform);
    }
}
