using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class User
    {
        // Identificador do usuário
        [Key]
        [Column("ID_USU")]
        public int IdUsu { get; set; }

        // Nome do usuário
        [MaxLength(100)]
        [Column("NOM_USU")]
        public string? NomUsu { get; set; }

        // Login de acesso do usuário
        [MaxLength(20)]
        [Column("COD_ACE_USU")]
        public string? CodAceUsu { get; set; }

        // E-mail do usuário
        [MaxLength(100)]
        [Column("DES_EMAIL_USU")]
        public string? DesEmailUsu { get; set; }

        // Código do perfil do usuário (1 - Consulta AP, 2 - Analista AP, 3 - Gestor AP, 9 - Administrador)
        [MaxLength(1)]
        [Column("COD_PER_USU")]
        public string? CodPerUsu { get; set; }

        // Status do registro (A - Ativo, I - Inativo)
        [MaxLength(1)]
        [Column("IND_STA_REG")]
        public string? IndStaReg { get; set; }

        // Data do cadastramento
        [Column("DAT_INI_CAD")]
        public DateTime? DatIniCad { get; set; }

        // Data de cancelamento, com valor padrão definido no banco de dados
        [Column("DAT_FIM_CAD")]
        public DateTime? DatFimCad { get; set; } = DateTime.Parse("9999-12-31");

        // Data da última alteração
        [Column("DAT_ULT_ALT")]
        public DateTime? DatUltAlt { get; set; }
    }
}
