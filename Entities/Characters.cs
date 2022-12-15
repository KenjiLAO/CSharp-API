namespace monAPI.Entities
{
    public class Characters
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Region region { get; set; }

        public virtual Vision vision { get; set; }

        public virtual Weapon weapon { get; set; }

    }
}
