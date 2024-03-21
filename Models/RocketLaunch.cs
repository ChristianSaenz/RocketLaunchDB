namespace Rocket_Launch_Database__2_.Models
{
    public class RocketLaunch
    {
        public int Id { get; set; }
        public int LaunchSiteId { get; set; }
        public int LaunchVehicleId { get; set; }
        public int PayloadId { get; set; }
        public int UserId { get; set; }
        public DateTime LaunchDate { get; set; }
        public string MissionOutcome { get; set; }
        
       

        public virtual LaunchSite LaunchSite { get; set; }
        public virtual LaunchVehicle LaunchVehicle { get; set; }
        public virtual Payload Payload { get; set; }
        public virtual User User { get; set; }
    }
}
