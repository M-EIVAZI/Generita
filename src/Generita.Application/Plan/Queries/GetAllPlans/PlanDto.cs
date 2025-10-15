namespace Generita.Application.Plan.Queries.GetAllPlans
{
    public class PlanDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        //Duration is in Days 
        public int Duration { get; set; }
    }
}
