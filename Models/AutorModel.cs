using System.Text.Json.Serialization;

namespace WebApi8_Video.Models
{
    public class AutorModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public string sobrenome { get; set; }

        [JsonIgnore]
        public ICollection<LivroModel> Livro { get; set; }
    }
}
