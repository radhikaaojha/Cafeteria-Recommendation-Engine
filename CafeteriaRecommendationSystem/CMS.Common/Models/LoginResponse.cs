namespace Common.Models
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }

}
