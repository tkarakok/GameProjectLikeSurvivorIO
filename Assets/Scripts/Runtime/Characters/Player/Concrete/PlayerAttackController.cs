
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DG.Tweening;
    using UnityEngine;

    public class PlayerAttackController : CharacterAttackController
    {
        public override void Attack()
        {
            base.Attack();
            
            if (_targetDamagable == null || _targetDamagable.GetIsDead()) return;
            if (_isCoolDown) return;

            var bullet = ObjectPoolManager.Instance.ObjectPoolController.GetPool(PoolType.Bullet).Data.GetPoolObject();
            
            bullet.transform.position = transform.position + Vector3.up;

            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 10;
            
            // bullet.transform.SetParent(_target.transform);
            // bullet.transform.DOLocalMove(Vector3.up, .25f).OnComplete(() =>
            // {
            //     _targetDamagable.TakeDamage(25);
            // });
            _isCoolDown = true;
            DOVirtual.DelayedCall(_coolDownTimer, () => _isCoolDown = false);
        }

        public override void Update()
        {
            base.Update();
            Attack();
        }
    }