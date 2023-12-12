using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : CharacterAnimationController, IEnemyAnim
{
    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}
