namespace WinFlows.Expressions
{
    public enum ExpressionTypes
    {
        Logical,
        Number,
        String,
        ListOfLogicals,
        ListOfNumbers,
        ListOfStrings,
        NotSet  // NotSet is only used as a placeholder for assignment, until we find out what the user wants to assign
    }
}
