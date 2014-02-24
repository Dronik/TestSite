namespace Test.Model.Model
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int? HomeAddressId { get; set; }
        public int? BusinessAddressId { get; set; }
        public Address HomeAddress { get; set; }
        public Address BusinessAddress { get; set; }
    }


}
