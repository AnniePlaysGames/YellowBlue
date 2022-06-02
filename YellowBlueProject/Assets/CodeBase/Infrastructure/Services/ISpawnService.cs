using CodeBase.Components;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface ISpawnService : IService
    { 
        WayPoint[] WayPoints { get; }
        void SpawnEnemies();
        void SpawnCharacter();
        void InitEnemySpawnPoints(string levelName);
        void InitCharacterSpawnPoint(string levelName);
        void InitWayPoints(string levelName);
    }
}