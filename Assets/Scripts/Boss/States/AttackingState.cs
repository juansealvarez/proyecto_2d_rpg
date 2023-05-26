using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class AttackingState : FSMState<BossController>
    {

        private int random;
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
            Debug.Log("attack");
            
            mController.animator.SetTrigger("Attack2");
            mController.hitBox.gameObject.SetActive(true);
            Debug.Log("attack 2");
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
