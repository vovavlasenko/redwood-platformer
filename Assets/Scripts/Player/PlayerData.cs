using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public float RunMaxSpeed; // ������������ ������� ��������
    public float RunAcceleration; // ����� �� ������� �������� ��������� ���� ��������
    public float RunDecceleration; // ����� �� ������� �������� �����������

    // ����, ������� ��������� � ������ ��� ��������� � ����������
    [HideInInspector] public float RunAccelAmount;
    [HideInInspector] public float RunDeccelAmount;

    private void OnValidate()
    {
        // ������������ ���� �� ������� ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
        RunAccelAmount = 50 * RunAcceleration / RunMaxSpeed;
        RunDeccelAmount = 50 * RunDecceleration / RunMaxSpeed;

        RunAcceleration = Mathf.Clamp(RunAcceleration, 0.01f, RunMaxSpeed);
        RunDecceleration = Mathf.Clamp(RunDecceleration, 0.01f, RunMaxSpeed);
    }
}
