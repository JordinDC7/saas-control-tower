
using System.Collections.Generic;
using Domain.Jobs;

namespace Domain.Risk
{
    public static class JobRiskEvaluator
    {
        public static JobRiskSummary Evaluate(Job job)
        {
            var reasons = new List<RiskReason>();
          
            if (string.IsNullOrWhiteSpace(job.ScopeDescription))
            {
                reasons.Add(RiskReason.MissingScopeDescription);
            }
            if (!job.EstimatedBudget.HasValue || job.EstimatedBudget.Value <= 0)
            {
                reasons.Add(RiskReason.MissingEstimatedBudget);
            }
            if (!job.RequiredCrewSize.HasValue || job.RequiredCrewSize.Value <= 0)
            {
                reasons.Add(RiskReason.MissingRequiredCrewSize);
            }

            if (!job.RequiredByDate.HasValue)
            {
                reasons.Add(RiskReason.MissingRequiredByDate);
            }

            if (string.IsNullOrWhiteSpace(job.Location))
            {
                reasons.Add(RiskReason.MissingLocation);
            }


            if (job.EstimatedBudget.HasValue && job.EstimatedBudget.Value > 0 && job.CommittedCost.HasValue && job.CommittedCost.Value > job.EstimatedBudget.Value)
            {
                reasons.Add(RiskReason.OverBudget);
            }

            if (!job.HasMaterialPlan)
            {
                reasons.Add(RiskReason.MissingMaterialPlan);

            }


            if (job.RequiredCrewSize.HasValue && job.RequiredCrewSize.Value > 0)
            {
                var assigned = job.AssignedCrewSize ?? 0;


                if (assigned < job.RequiredCrewSize.Value)
                {
                    reasons.Add(RiskReason.Understaffed);
                }


            }
            RiskLevel level;
            
            if (reasons.Contains(RiskReason.Understaffed) || reasons.Contains(RiskReason.OverBudget))
                     level = RiskLevel.High;
                else if (reasons.Count > 0)
                     level = RiskLevel.Medium;
                else level = RiskLevel.Low;

            


            return new JobRiskSummary(level, reasons);

        }

    }
}
  

