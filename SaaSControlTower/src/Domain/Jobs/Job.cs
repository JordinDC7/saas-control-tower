namespace Domain.Jobs
{
    public sealed class Job
    {
        public Guid Id { get; private set; }
        public string? ScopeDescription { get; private set; }
        public decimal? EstimatedBudget { get; private set; }
        public decimal? CommittedCost { get; private set; }
        public int? RequiredCrewSize { get; private set; }
        public int? AssignedCrewSize { get; private set; }
        public bool HasMaterialPlan { get; private set; }
        public DateOnly? RequiredByDate { get; private set; }
        public string? Location { get; private set; }

        public Job(Guid id, string? scopeDescription, decimal? estimatedBudget, decimal? committedCost, int? requiredCrewSize, int? assignedCrewSize, bool hasMaterialPlan, DateOnly? requiredByDate, string? location)
        {
            Id = id;
            ScopeDescription = scopeDescription;
            EstimatedBudget = estimatedBudget;
            CommittedCost = committedCost;
            RequiredCrewSize = requiredCrewSize;
            AssignedCrewSize = assignedCrewSize;
            HasMaterialPlan = hasMaterialPlan;
            RequiredByDate = requiredByDate;
            Location = location;
        }

    }
}
