
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public abstract class CharacterAttackController : MonoBehaviour, ICharacterAttackController
    {
        [SerializeField] protected float _coolDownTimer;
        [SerializeField] private float _checkEnemyTimer;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _targetLayerMask;
        
        private float _timer;
        protected bool _isCoolDown;
        
        private List<Collider> _enemies = new List<Collider>();
        protected IDamagable _targetDamagable;
        public GameObject _target { get; private set; }

        public virtual void Update()
        {
            GetEnemies();
        }

        public virtual void GetEnemies()
        {
            if (_targetDamagable != null && !_targetDamagable.GetIsDead()) return;
            _timer += Time.deltaTime;
            if (_timer < _checkEnemyTimer) return;
            _timer = 0;
            
            _enemies = Physics.OverlapSphere(transform.position, _radius, _targetLayerMask).ToList().
                Where(e => e.GetComponent<CharacterHealthController>().GetIsDead() == false).ToList();

            if (_enemies.Count == 0) return;
            _targetDamagable = _enemies[0].GetComponent<IDamagable>();
            _target = _enemies[0].gameObject;
        }

        public virtual void Attack()
        {
        }

        public bool HasAliveTargetInRange()
        {
            if (_targetDamagable != null && _targetDamagable.GetIsDead() == false)
                return true;
            else
                return false;

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }