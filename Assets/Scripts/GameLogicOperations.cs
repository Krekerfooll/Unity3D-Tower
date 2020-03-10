public static class GameLogicOperations
{
    public static bool CheckConditionsByAndRule(Condition[] conditions)
    {
        foreach (Condition condition in conditions)
        {
            if (!condition.CheckCondition())
            {
                return false;
            }
        }

        return true;
    }
}
