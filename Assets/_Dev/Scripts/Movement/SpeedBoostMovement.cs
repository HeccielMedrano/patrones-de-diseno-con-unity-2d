public class SpeedBoostMovement : IMovementStrategy
{
    private IMovementStrategy wrappedStrategy;
    private float bonusMultiplier;

    public SpeedBoostMovement(IMovementStrategy baseStrategy, float multiplier)
    {
        wrappedStrategy = baseStrategy;
        bonusMultiplier = multiplier;
    }

    public float GetHorizontalSpeed(float baseSpeed)
    {
        return wrappedStrategy.GetHorizontalSpeed(baseSpeed) * bonusMultiplier;
    }
}
