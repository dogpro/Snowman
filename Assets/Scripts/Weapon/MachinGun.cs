using UnityEngine;

public class MachinGun : Weapon
{
    private void Start()
    {
        CurrentAmmo = MaxAmmo;
        // UI update ammo
    }

    public override void Shoot(Transform shootPoint, Vector3 dir)
    {
        SnowBallsPool.GetFreeElement(shootPoint.position,Quaternion.identity).GetComponent<SnowBall>().InitBullet(dir);
        MuzzleEffect(shootPoint);
    }
    public override void MuzzleEffect(Transform shootPoint)
    {
        //Instantiate muzzle prefab
    }
}
