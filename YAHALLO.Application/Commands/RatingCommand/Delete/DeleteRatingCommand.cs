using MediatR;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Delete
{
    public class DeleteRatingCommand: IRequest<bool>
    {
        public string TargetId { get; set; } = string.Empty;
        public RatingEnum RatingTo { get;set; }   
        public string UserId { get; set; } = string.Empty;  
    }
}
