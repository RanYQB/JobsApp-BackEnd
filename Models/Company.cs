namespace JobsApi.Models 
{
    public class Company
    {

        public int CompanyId {get; set;}
        public string Name {get; set;}
	   
        public Company()
        {
           
            if(Name == null)
            {
                Name = "";
            }
        }
    }
}