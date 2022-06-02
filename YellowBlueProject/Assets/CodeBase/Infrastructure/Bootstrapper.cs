using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private RectTransform _uiRoot;
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private void Awake()
        {
            Game game = new Game(this, _loadingCurtain, _uiRoot);
            game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}