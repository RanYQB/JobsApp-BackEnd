namespace JobsApi.Dtos 
{
    public class JobReadDto
    {
        public int JobId {get; set;}
        public string Title {get; set;}
        public DateTime StartedOn {get; set;}
        public DateTime EndedOn {get; set;}
        public bool IsCurrent {get; set;}
        public CompanyReadDto Company {get; set;} = null!;
	   
        public JobReadDto()
        {
           
            if(Title == null)
            {
                Title = "";
            }
        }
    }
}
