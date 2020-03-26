namespace AgroVision.Model
{
    public class UserCalculationModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public double Hectares { get; set; }

        public double MinimimSprayRate { get; set; }

        public double LitersPerHectare { get; set; }

        public double AgentAmount { get; set; }

        public double WaterAmount { get; set; }

        public string CropType { get; set; }

        public string SprayingAgent { get; set; }
    }
}
