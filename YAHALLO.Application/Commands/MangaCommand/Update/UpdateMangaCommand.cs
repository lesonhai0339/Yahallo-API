using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Commands.MangaCommand.Update
{
    public class UpdateMangaCommand: IRequest<ResponeResult>
    {
        public UpdateMangaCommand(
            string id,
            string? name,
            string? description,
            MangaLevel? level,
            MangaStatus? status,
            MangaType? type,
            CountriesEnum? countries,
            int? season,
            IFormFile? thumbnail)
        {
            Id = id;
            Name = name;
            Description = description;
            Level = level;
            Status = status;    
            Type = type;
            Countries = countries;
            Season = season;
            Thumbnail = thumbnail;
        }
        public string Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; }
        public MangaLevel? Level { get; set; }
        public MangaStatus? Status { get; set; }
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int? Season { get; set; }

        public IFormFile? Thumbnail { get; set; }
    }
}
