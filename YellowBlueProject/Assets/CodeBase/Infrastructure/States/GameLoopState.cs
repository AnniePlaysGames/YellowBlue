using System;
using CodeBase.Components;
using CodeBase.Infrastructure.Services.Factories;
using CodeBase.Infrastructure.States.Interfaces;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICreatureFactory _creatureFactory;

        public GameLoopState(GameStateMachine gameStateMachine, ICreatureFactory creatureFactory)
        {
            _gameStateMachine = gameStateMachine;
            _creatureFactory = creatureFactory;

        }

        public void Enter() 
            => _creatureFactory.Character.GetComponent<MoveByWayPoints>().StartMovement();

        public void Exit()
        {
            
        }
    }
}