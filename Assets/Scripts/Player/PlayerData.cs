using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public float RunMaxSpeed; // ћаксимальна€ целева€ скорость
    public float RunAcceleration; // ¬рем€ за которое персонаж достигнет макс скорости
    public float RunDecceleration; // ¬рем€ за которое персонаж остановитс€

    // —илы, которые примен€ем к игроку дл€ ускорени€ и замедлени€
    [HideInInspector] public float RunAccelAmount;
    [HideInInspector] public float RunDeccelAmount;

    private void OnValidate()
    {
        // –ассчитываем силы по формуле ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
        RunAccelAmount = 50 * RunAcceleration / RunMaxSpeed;
        RunDeccelAmount = 50 * RunDecceleration / RunMaxSpeed;

        RunAcceleration = Mathf.Clamp(RunAcceleration, 0.01f, RunMaxSpeed);
        RunDecceleration = Mathf.Clamp(RunDecceleration, 0.01f, RunMaxSpeed);
    }
}
