namespace JobsApi.Dtos 
{
    public class CompanyReadDto
    {
        public int CompanyId {get; set;}
        public string Name {get; set;}
	   
        public CompanyReadDto()
        {
           
            if(Name == null)
            {
                Name = "";
            }
        }
    }
}