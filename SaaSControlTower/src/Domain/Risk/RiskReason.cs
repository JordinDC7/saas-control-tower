namespace Domain.Risk
{
    public enum RiskReason
    {
        MissingScopeDescription,
        MissingEstimatedBudget,
        MissingRequiredCrewSize,
        MissingMaterialPlan,
        MissingRequiredByDate,
        MissingLocation,
        OverBudget,
        Understaffed
    }
}
