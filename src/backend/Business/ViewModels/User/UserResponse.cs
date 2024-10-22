using Newtonsoft.Json;
using System;

namespace Business.ViewModels
{
    public class UserResponse
    {
        [JsonProperty("idUsu")]
        public Guid IdUsu { get; set; } // Identificador do usuário

        [JsonProperty("nomUsu")]
        public string NomUsu { get; set; } // Nome do usuário

        [JsonProperty("codAceUsu")]
        public string CodAceUsu { get; set; } // Login de acesso do usuário

        [JsonProperty("desEmailUsu")]
        public string DesEmailUsu { get; set; } // E-mail do usuário

        [JsonProperty("codPerUsu")]
        public string CodPerUsu { get; set; } // Código do perfil do usuário

        [JsonProperty("indStaReg")]
        public string IndStaReg { get; set; } // Status do registro

        [JsonProperty("datIniCad")]
        public DateTime? DatIniCad { get; set; } // Data do cadastramento

        [JsonProperty("datFimCad")]
        public DateTime? DatFimCad { get; set; } // Data de cancelamento

        [JsonProperty("datUltAlt")]
        public DateTime? DatUltAlt { get; set; } // Data da última alteração

    }
}
