using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciatripapiMysql.Models
{
    [Table("destino_tb")]
    public class DestinoModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Informe o destino.")]
        public string Destino { get; set; }
        [Required(ErrorMessage = "Informe a origem.")]
        public string Origem { get; set; }
        [Required(ErrorMessage = "Insira uma imagem.")]
        public string Imagem { get; set; }
        [Required(ErrorMessage = "Insira um valor.")]
        public double Valor { get; set; }
    }
}
