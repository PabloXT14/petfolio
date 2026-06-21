using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(Guid id)
    {
        // Simulate a exception
        // throw new InvalidOperationException("Pet não encontrado.");
        
        var response = new ResponsePetJson
        {
            Id = id,
            Name = "Rex",
            Birthdate = new DateTime(year: 2020, month: 5, day: 15),
            Type = PetType.Dog
        };

        return response;
    }
}