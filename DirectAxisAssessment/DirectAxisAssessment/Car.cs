using System;

namespace DirectAxisAssessment
{
    public class Car
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int Acceleration { get; set; }
        public int Braking { get; set; }
        public int Cornering { get; set; }
        public int TopSpeed { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Score { get; set; }
    }
}
