using System;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;

        private void Awake() 
            => _animator = GetComponent<Animator>();

        public void StartMove() 
            => _animator.SetBool(IsRunning, true);

        public void FinishMove() 
            => _animator.SetBool(IsRunning, false);

        public void DoAttack() 
            => _animator.SetTrigger(Attack);
    }
}