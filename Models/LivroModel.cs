namespace WebApi8_Video.Models
{
    public class LivroModel
    {
        public string Id { get; set; }
        
        public string Titulo { get; set; }

        public AutorModel Autor { get; set; }
    }
}
