using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    // Para implementación de ataque especial si se hace.
    public class SpecialAttackState : FSMState<BossController>
    {
        public SpecialAttackState(BossController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<BossController>(
                isValid: () => mController.SpecialAttackEnd,
                getNextState: () => new IdleState(mController)
            ));
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter SpecialAttackState");
            mController.animator.SetTrigger("SpecialAttack");
            mController.specialAttackHitBox.gameObject.SetActive(true);
        }

        public override void OnExit()
        {
            Debug.Log("OnExit SpecialAttackState");
            mController.specialAttackHitBox.gameObject.SetActive(false);
        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }
}
