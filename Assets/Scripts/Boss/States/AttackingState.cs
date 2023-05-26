using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class AttackingState : FSMState<BossController>
    {
        public AttackingState(BossController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<BossController>(
                isValid: () => mController.AttackingEnd,
                getNextState: () => new IdleState(mController)
            ));
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter BossAttackingState");
            mController.animator.SetTrigger("Attack");
            mController.hitBox.gameObject.SetActive(true);
        }

        public override void OnExit()
        {
            Debug.Log("OnExit BossAttackingState");
            mController.animator.SetTrigger("Attack");
            mController.hitBox.gameObject.SetActive(true);
        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }
}
