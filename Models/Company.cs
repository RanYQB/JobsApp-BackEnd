namespace JobsApi.Models 
{
    public class Company
    {

        public int CompanyId {get; set;}
        public string Name {get; set;}
        public ICollection<Job> Jobs { get;} = new List<Job>(); 
	   
        public Company()
        {
           
            if(Name == null)
            {
                Name = "";
            }
        }
    }
}