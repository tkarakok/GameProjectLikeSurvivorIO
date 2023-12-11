
    using System.Collections;

    public interface ICharacterAttackController
    {
        void GetEnemies();
        void Attack();
        bool HasAliveTargetInRange();
    }