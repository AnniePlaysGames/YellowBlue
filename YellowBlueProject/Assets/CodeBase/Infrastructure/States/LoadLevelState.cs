using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States.Interfaces;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly ISpawnService _spawnService;
        private string _levelName;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, ISpawnService spawnService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _spawnService = spawnService;
        }

        public void Enter(string sceneName)
        {
            _levelName = sceneName;
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _spawnService.InitCharacterSpawnPoint(_levelName);
            _spawnService.InitWayPoints(_levelName);
            _spawnService.InitEnemySpawnPoints(_levelName);
            _spawnService.SpawnEnemies();
            _spawnService.SpawnCharacter();

            
            _gameStateMachine.Enter<PauseMenuState>();
        }

        public void Exit() 
            => _curtain.Hide();
    }
}