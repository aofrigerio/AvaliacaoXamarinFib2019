using System;
using System.Runtime.Serialization;

namespace MultPlatProject
{
    // Esse atributo indica que a classe possui um contrato de dados, i.e. ela
    // é (des)serializada de maneira diferente como de fato é.
    // No nosso caso, todos os DTOs devem ter este atributo, pois o padrão de
    // nomeação do C# é diferente do padrão do banco de dados (capitaliza 1a letra).
    [DataContract]
    public class BaseDTO
    {
        // Esse atributo indica qual o nome da propriedade Created quando uma
        // instância dessa classe for (des)serializada.
        [DataMember(Name = "created")]
        public long? Created
        {
            get;
            set;
        }

        [DataMember(Name = "updated")]
        public long? Updated
        {
            get;
            set;
        }

        [DataMember(Name = "objectId")]
        public string ObjectId
        {
            get;
            set;
        }
    }
}
