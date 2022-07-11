namespace Train
{
    public class Station
    {
        private string name;
        private string town;
        private string province;

        public Station(string name, string town, string province)
        {
            this.name = name;
            this.town = town;
            this.province = province;
        }

        public string Name
        {
            get { return name; }
        }

        public string Town
        {
            get { return town; }
        }

        public string Province
        {
            get { return province; }
        }
    }
}