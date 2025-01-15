namespace JobsApi.Dtos 
{
    public class CompanyCreateDto
    {
        public string Name {get; set;}
        
        public CompanyCreateDto()
        {
           
            if(Name == null)
            {
                Name = "";
            }
        }
    }
}