namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, (int, int) location, Person owner)
        {
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {

            if(Size ==Size.Default)
            {
                return "";
            }
            return $"Owner: {Owner.ToString()} Location: {Location.ToString()} Size: {Size}";
        }

    }

}
