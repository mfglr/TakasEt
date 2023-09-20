using Application.Dtos;
using HttpMultipartParser;

namespace Function.Extentions
{
	public static class MultipartFormDataParserExtentions
	{

		public static string? GetValueByName(this MultipartFormDataParser parser, string name)
		{
			return parser.Parameters.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => x.Data).FirstOrDefault();
		}

		public static UploadFileRequestDto Parse( this MultipartFormDataParser parser)
		{
			return new UploadFileRequestDto(
				parser.Files.Select(x => x.Data),
				GetValueByName(parser,"containerName"),
				Guid.Parse(GetValueByName(parser,"ownerId")),
				GetValueByName(parser,"extention")
			);
		}
	}
}
