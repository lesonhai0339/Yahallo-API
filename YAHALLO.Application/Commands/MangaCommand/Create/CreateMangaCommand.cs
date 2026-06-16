using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.MangaCommand.DTOs;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Commands.MangaCommand.Create
{
    public class CreateMangaCommand : IRequest<CreateMangaResponseDto>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public MangaLevel Level { get; set; }
        public MangaStatus Status { get; set; }
        public MangaType Type { get; set; }
        public CountriesEnum Countries { get; set; }
        public int Season { get; set; }
        public IFormFile? Avatar { get; set; }
        public IFormFile? Background { get; set; }
        public string? MangaGroupId { get; set; }
    }
}
