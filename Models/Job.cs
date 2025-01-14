namespace JobsApi.Models 
{
    public class Job
    {
        public int JobId {get; set;}
        public string Title {get; set;}
        public DateTime StartedOn {get; set;}
        public DateTime EndedOn {get; set;}
        public bool IsCurrent {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public int CompanyId {get; set;}
        public Company Company {get; set;}
	   
        public Job()
        {
           
            if(Title == null)
            {
                Title = "";
            }
        }
    }
}
