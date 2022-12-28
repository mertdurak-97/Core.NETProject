namespace Core.NETProject.Models


{
    public class AddProfileImage
    {
        //modelin içine neden yeniden entityler göndermemizin sebebi bu ımage değişiklliğini yeniden entity katmanında yapmamak istememizin sonucunda oluşturuldu.
        //ımage özel alanı kodu ise ; IFormFile (Dosyadan resim jpg seçebilmek için)
        public int WriterID { get; set; }
        public string? WriterName { get; set; }
        public string? WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string? WriterMail { get; set; }
        public string? WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
