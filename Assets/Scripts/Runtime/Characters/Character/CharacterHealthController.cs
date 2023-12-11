
    using System;
    using UnityEngine;

    public abstract class CharacterHealthController : MonoBehaviour, IDamagable, ICharacterHealthController
    {
        private Character _character;
        private bool _isDead { get;  set; }

        private void Start()
        {
            _character = GetComponent<Character>();
            SetCharacterHealthData(_character.CharacterData);
        }

        public void TakeDamage(int damage)
        {
            if (_isDead) return;
            _character.MaxHealth -= damage;
            if (_character.MaxHealth <= 0)
            {
                _isDead = true;
            }
        }

        public bool GetIsDead()
        {
            return _isDead;
        }


        public void SetCharacterHealthData(CharacterData characterData)
        {
            _character.MaxHealth = characterData.MaxHealth;
        }
    }