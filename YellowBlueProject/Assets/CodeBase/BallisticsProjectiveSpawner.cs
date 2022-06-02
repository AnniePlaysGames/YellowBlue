using System.Collections;
using CodeBase.Components;
using UnityEngine;

public class BallisticsProjectiveSpawner : MonoBehaviour {
    
    private readonly float _gravity = Physics.gravity.y;

    public void Shot(Vector3 startPosition, Vector3 targetPosition, float angleInDegrees, WeaponPool weaponPool) 
    {
        transform.localEulerAngles = new Vector3(-angleInDegrees, 0f, 0f);
        Vector3 directionToTarget = targetPosition - transform.position;
        Vector3 directionToTargetXZ = new Vector3(directionToTarget.x, 0f, directionToTarget.z);
        transform.rotation = Quaternion.LookRotation(directionToTargetXZ, Vector3.up);
        
        GameObject projective = weaponPool.GetPooledWeapon();
        projective.transform.position = startPosition;
        projective.SetActive(true);
        
        float x = directionToTargetXZ.magnitude;
        float y = directionToTarget.y;
        projective.GetComponent<Rigidbody>().velocity = transform.forward * CalculateVelocity(x, y, angleInDegrees);
        
        StartCoroutine(RespawnWeapon(projective));
    }
    
    IEnumerator RespawnWeapon(GameObject projective)
    {
        yield return new WaitForSeconds(15);
        projective.SetActive(false);
    }

    private float CalculateVelocity(float x, float y, float angleInDegrees)
    {
        float angleInRadians = angleInDegrees * Mathf.PI / 180;
        float v2 = (_gravity * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        return Mathf.Sqrt(Mathf.Abs(v2));
    }
}
