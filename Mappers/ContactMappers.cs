using WebContacts.Dtos;
using WebContacts.Models;

namespace WebContacts.Mappers
{
    public static class ContactMappers {
        public static ContactDto ToContactDto(this Contact contactModel) {
            return new ContactDto {
                Id = contactModel.Id,
                PhoneNumber = contactModel.PhoneNumber,
                FirstName = contactModel.FirstName,
                MiddleName = contactModel.MiddleName,
                LastName = contactModel.LastName,
            };
        }

        public static Contact ToContactFromCreateDTO(this CreateContactRequestDto contactDto) {
            return new Contact {
                PhoneNumber = contactDto.PhoneNumber,
                FirstName = contactDto.FirstName,
                MiddleName = contactDto.MiddleName,
                LastName = contactDto.LastName,
            };
        }
    }
}
