using CodeBase.Components;
using CodeBase.Infrastructure.Services.AssetManagment;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class SpawnService : ISpawnService
    {
        private const string SpawnFolderName = "Spawn";
        private const string EnemyPointFileName = "EnemySpawnPointContainer";
        private const string PlayerPointFileName = "CharacterSpawnPoint";
        private const string WaypointContainerFileName = "WaypointContainer";
        
        private readonly IAssetProvider _assetProvider;
        private EnemySpawnPoint[] _enemySpawnPoints;
        private CharacterSpawnPoint _characterSpawnPoint;
        private WayPoint[] _wayPoints;
        
        public WayPoint[] WayPoints => _wayPoints;

        public SpawnService(IAssetProvider assetProvider) 
            => _assetProvider = assetProvider;
        
        public void InitCharacterSpawnPoint(string levelName)
        {
            GameObject point = _assetProvider.Instantiate($"{SpawnFolderName}/{levelName}/{PlayerPointFileName}");
            _characterSpawnPoint = point.GetComponent<CharacterSpawnPoint>();
        }

        public void InitEnemySpawnPoints(string levelName)
        {
            GameObject container = _assetProvider.Instantiate($"{SpawnFolderName}/{levelName}/{EnemyPointFileName}");
            _enemySpawnPoints = container.GetComponentsInChildren<EnemySpawnPoint>();
        }

        public void InitWayPoints(string levelName)
        {
            GameObject container = _assetProvider.Instantiate($"{SpawnFolderName}/{levelName}/{WaypointContainerFileName}");
            _wayPoints = container.GetComponentsInChildren<WayPoint>();
        }

        public void SpawnEnemies()
        {
            foreach (EnemySpawnPoint point in _enemySpawnPoints)
            {
                point.Spawn();
            }
        }

        public void SpawnCharacter()
        {
            _characterSpawnPoint.Spawn();
        }
    }
}