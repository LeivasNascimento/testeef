using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é de preenchimento obrigatório")]
        [MaxLength(60,ErrorMessage ="Nome deve ter entre 3 e 60 caracteres")]
        [MinLength(3,ErrorMessage ="Nome deve ter entre 3 e 60 caracteres")]
        public string Title { get; set; }

    }
    
}