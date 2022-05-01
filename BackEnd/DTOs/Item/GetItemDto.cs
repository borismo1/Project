namespace BackEnd.DTOs.Item
{
    public class GetItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public double Price { get; set; }

        public int Category { get; set; }
    }
}
