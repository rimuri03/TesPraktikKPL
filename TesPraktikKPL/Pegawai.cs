namespace TesPraktikKPL
{
    public class Pegawai
    {
        public string Nama { get; private set; }
        public string ID { get; private set; }

        public Pegawai(string Nama, string ID)
        {
            this.Nama = Nama;
            this.ID = ID;
        }
    }
}
