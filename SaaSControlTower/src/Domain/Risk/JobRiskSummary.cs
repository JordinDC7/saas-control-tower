namespace Domain.Risk
{
    public record JobRiskSummary(
        RiskLevel Level,
        IReadOnlyList<RiskReason> Reasons
        );
}
