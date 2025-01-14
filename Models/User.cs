namespace JobsApi.Models 
{
    public class User
    {

        public int UserId {get; set;}
        public string LastName {get; set;}
	    public string FirstName {get; set;} 
        public DateTime DateOfBirth {get; set;}
	   
        public User()
        {
            if(LastName == null)
            {
                LastName = "";
            }
            if(FirstName == null)
            {
                FirstName = "";
            }
        }
    }
}