using UnityEngine;

public class BulletLoot : Loot
{
    public override void AddLootToPlayer(GameObject player)
    {
        if (player.TryGetComponent(out PlayerAmmo playerAmmo))
        {
            playerAmmo.ChangeBulletAmount(BonusAmount);
        }
    }

}
