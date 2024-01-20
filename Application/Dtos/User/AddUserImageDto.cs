using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class AddUserImageDto : IRequest<AppResponseDto>
    {
        public int? UserId { get; private set; }
        public string? Extention { get; private set; }
        public Stream? Stream { get; private set; }
      
        public AddUserImageDto(IFormCollection form)
        {
            UserId = form.ReadInt("userId");
            Extention = form.ReadString("extention");
            Stream = form.ReadStream();
        }
    }
}
