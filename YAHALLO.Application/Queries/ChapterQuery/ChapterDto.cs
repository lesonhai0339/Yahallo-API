using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.ChapterQuery
{
    public class ChapterDto : IMapFrom<ChapterEntity>
    {
<<<<<<< HEAD
=======
        public required string Id { get; set; }
>>>>>>> master
        public string? Title { get; set; }
        public int Index { get; set; }

        public string MangaId { get; set; } = null!;
<<<<<<< HEAD
        public string? MangaName { get; set; }

        public static ChapterDto CreateMap(
            string? title,
            int index,
            string mangaid,
            string? manganame)
        {
            return new ChapterDto
            {
                Title = title,
                Index = index,
                MangaId= mangaid,
                MangaName= manganame
            };              
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterEntity, ChapterDto>();
=======
        public string? MangaName { get; set; }   
        public static ChapterDto CreateMap(string id, string? title, int index, string mangaid, string manganame)
        {
            return new ChapterDto
            {
                Id = id,
                Title = title,  
                Index = index,
                MangaId = mangaid,
                MangaName = manganame
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterDto, ChapterEntity>();
>>>>>>> master
        }
    }
}
