namespace SloppyJoes
{
    public class MenuItem
    {

        public MenuItem(string meat, string condiment, string bread)
        {
            Meat = meat;
            Condiment = condiment;
            Bread = bread;
        }

        public string Meat { get; private set; }
        public string Bread { get; private set; }
        public string Condiment { get; private set; }

        public override string ToString()
        {
            return $"{Meat} with {Condiment} on {Bread}";
        }

    }
}