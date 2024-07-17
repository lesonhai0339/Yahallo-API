using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.CommentQuery
{
    public class CommentDto : IMapFrom<CommentEntity>
    {
        public required string Id { get;set; }
        public string? UserId { get;set; }
        public string? MangaId { get;set; }
        public string? Message { get;set; }
        public DateTime? DateTime { get;set; } 
        public int Like { get;set; }
        public int Dislike { get;set; }
        public static CommentDto Create(string id, string userid, string mangaid, string message,DateTime datetime, int like, int dislike)
        {
            return new CommentDto
            {
                Id = id,
                UserId = userid,
                MangaId = mangaid,
                Message = message,  
                DateTime = datetime,
                Like = like,
                Dislike = dislike
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommentEntity, CommentDto>();
        }
    }
}
