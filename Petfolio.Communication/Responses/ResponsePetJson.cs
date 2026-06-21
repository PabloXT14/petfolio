using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Responses;

public class ResponsePetJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } =  string.Empty;
    public DateTime Birthdate { get; set; }
    public PetType Type { get; set; }
}