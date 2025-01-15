namespace JobsApi.Dtos
{
    public class UserCreateDto
    {
        public string LastName {get; set;}
	    public string FirstName {get; set;} 
        public DateTime DateOfBirth {get; set;}
	   
        public UserCreateDto()
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