using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class IdleState : FSMState<BossController>
    {
        public IdleState(BossController controller) : base(controller)
        {
            // Transiciones
            /*Transitions.Add(new FSMTransition<BossController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        mController.transform.position,
                        mController.Player.transform.position
                    ) < mController.WakeDistance;
                },
                getNextState: () =>
                {
                    return new MovingState(mController);
                }
            ));*/

            Transitions.Add(new FSMTransition<BossController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        mController.transform.position,
                        mController.Player.transform.position
                    ) <= mController.AttackDistance;
                },
                getNextState: () =>
                {
                    return new AttackingState(mController);
                }
            ));
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter BoosIdleState");
            mController.animator.SetBool("IsMoving", false);
            mController.AttackingEnd = false;
        }

        public override void OnExit()
        {
            Debug.Log("OnExit BossIdleState");
        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }
}
