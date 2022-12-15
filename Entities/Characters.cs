namespace monAPI.Entities
{
    public class Characters
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Region? region { get; set; }

        public Vision? vision { get; set; }

        public Weapon? weapon { get; set; }

    }
}
