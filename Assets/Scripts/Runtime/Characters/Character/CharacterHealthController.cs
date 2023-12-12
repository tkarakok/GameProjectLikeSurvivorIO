
    using System;
    using UnityEngine;

    public abstract class CharacterHealthController : MonoBehaviour, IDamagable, ICharacterHealthController
    {
        private Character _character;
        private ICharacterAnim _characterAnim;
        public bool IsDead { get;  set; }

        private void Start()
        {
            _character = GetComponent<Character>();
            _characterAnim = GetComponent<ICharacterAnim>();
            SetCharacterHealthData(_character.CharacterData);
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            _character.MaxHealth -= damage;
            if (_character.MaxHealth <= 0)
            {
                _characterAnim.Death();
                IsDead = true;
            }
        }

        public bool GetIsDead()
        {
            return IsDead;
        }


        public void SetCharacterHealthData(CharacterData characterData)
        {
            _character.MaxHealth = characterData.MaxHealth;
        }
    }