using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll;

public class GetAllPetsUseCase
{
    public ResponseAllPetJson Execute()
    {
        // Simulate fetching pets from a data source
        var pets = new List<ResponseShortPetJson>
        {
            // new ResponseShortPetJson { Id = Guid.NewGuid(), Name = "Buddy", Type = PetType.Dog },
            // new ResponseShortPetJson { Id = Guid.NewGuid(), Name = "Mittens", Type = PetType.Cat }
        };

        var response = new ResponseAllPetJson
        {
            Pets = pets
        };

        return response;
    }
}