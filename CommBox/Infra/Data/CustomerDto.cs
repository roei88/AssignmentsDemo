namespace CommBox.Infra.Data
{
    public class CustomerDto
    {
        public int Id { get; set; } // Ensure this property exists
        public string Name { get; set; } = string.Empty; // Non-nullable by default
        public string PreferredChannel { get; set; } = string.Empty; // Non-nullable by default
    }
}
