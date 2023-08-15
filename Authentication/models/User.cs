namespace Authentication.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Slug { get; set; }
        public List<Role> Roles { get; set; }
        public List<Links> Links { get; set; }
    }
}