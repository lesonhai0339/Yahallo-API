using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Commands.ArtistCommand.Update
{
    public class UpdateArtistCommand: IRequest<string>
    {
        public UpdateArtistCommand(
            string id,
            string? name, 
            CountriesEnum? countries, 
            string? depscription, 
            DateTime? birth, 
            LifeStatus? lifeStatus)
        {
            Id = id;
            Name = name;
            Countries = countries;
            Depscription = depscription;
            Birth = birth;
            LifeStatus = lifeStatus;
        }
        public string Id { get; set; }
        public string? Name { get; set; }
        public CountriesEnum? Countries { get; set; }
        public string? Depscription { get; set; }
        public DateTime? Birth { get; set; }
        public LifeStatus? LifeStatus { get; set; }

    }
}
