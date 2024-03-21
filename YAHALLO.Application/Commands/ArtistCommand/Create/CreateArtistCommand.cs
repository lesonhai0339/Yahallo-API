using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Commands.ArtistCommand.Create
{
    public class CreateArtistCommand: IRequest<string>
    {
        public CreateArtistCommand(
            string name,
            int countrycode,
            string depscription,
            DateTime birth,
            int lifestatus) 
        {
            Name=   name;
            CountryCode = countrycode;
            Depscription = depscription;
            Birth = birth;
            LifeStatus = lifestatus;
        }
        public string Name { get; set; } = null!;
        public int CountryCode { get; set; }
        public string Depscription { get; set; } = null!;
        public DateTime Birth { get; set; }
        public int LifeStatus { get; set; }
    }
}
