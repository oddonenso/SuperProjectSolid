namespace SuperProject.Model
{
    public class UpdateClient
    {
        public int Id { get; set; }
        public string Country {  get; set; }
        public string Password {  get; set; }

        public bool isValidation
        {
            get => Id > 0 && Country.Length >= 3 && Password.Length >= 3;
        }
    }
}
