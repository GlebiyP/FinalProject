using SQLite;

namespace FinalProject.Database
{
    public class DataModel
    {
        public DataModel() { }

        public DataModel(string year, double urbanPopulation, double ruralPopulation)
        {
            Year = year;
            UrbanPopulation = urbanPopulation;
            RuralPopulation = ruralPopulation;
            Total = urbanPopulation + ruralPopulation;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Year { get; set; }
        public double UrbanPopulation { get; set; }
        public double RuralPopulation { get; set; }
        public double Total { get; set; }
    }
}