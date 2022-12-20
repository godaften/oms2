namespace OMS.CoreBusiness
{
    public class Lejer
    {
        public int LejerID { get; set; }
        public string Navn { get; set;} = string.Empty;
        public string Telefon { get; set; } = string.Empty;
       


        // FK
        // kontorfællesskabID
        // public int BygningID { get;}
    }
}