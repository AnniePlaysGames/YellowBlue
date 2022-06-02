using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
    public interface IWeaponFactory : IService
    {
        GameObject CreateWeapon();
    }
}