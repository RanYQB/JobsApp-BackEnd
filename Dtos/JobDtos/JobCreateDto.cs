namespace JobsApi.Dtos 
{
    public class JobCreateDto
    {
        public string Title {get; set;}
        public DateTime StartedOn {get; set;}
        public DateTime EndedOn {get; set;}
        public bool IsCurrent {get; set;}
        public int UserId {get; set;}
        public int CompanyId {get; set;}
	   
        public JobCreateDto()
        {
           
            if(Title == null)
            {
                Title = "";
            }
        }
    }
}
