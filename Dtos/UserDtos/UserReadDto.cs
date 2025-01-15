namespace JobsApi.Dtos
{
    public class UserReadDto
    {
        public int UserId {get; set;}
        public string LastName {get; set;}
	    public string FirstName {get; set;} 
        public DateTime DateOfBirth {get; set;}
        public ICollection<JobReadDto> Jobs { get; } = new List<JobReadDto>(); 
	   
        public UserReadDto()
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