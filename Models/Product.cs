
using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
        public class Product
        {
                [Key]
                public int Id { get; set; }

                [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
                [MaxLength(60,ErrorMessage ="Nome deve ter entre 3 e 60 caracteres")]
                [MinLength(3,ErrorMessage ="Nome deve ter entre 3 e 60 caracteres")]
                public string Title { get; set; }

                [MaxLength(1024, ErrorMessage="Este campo deve ter no máximo 1024 caracteres")]
                public string Description { get; set; }

                [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
                [Range(1, int.MaxValue, ErrorMessage="o preço deve ser maior que zero")]
                public decimal Price { get; set; }

                [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
                [Range(1, int.MaxValue, ErrorMessage="Categoria inválida")]
                public int CategoryId { get; set; }

                public Category Category { get; set; }
        }
}
