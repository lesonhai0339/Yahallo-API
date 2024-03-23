using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Commands.AuthorCommand.Create
{
    public class CreateAuthorCommand: IRequest<string>
    {
        public CreateAuthorCommand(
            string name,
            CountriesEnum countries,
            string depscription,
            DateTime birth,
            LifeStatus lifestatus)
        {
            Name = name;
            Countries= countries;
            Depscription = depscription;
            Birth = birth;
            LifeStatus = lifestatus;
        }
        public string Name { get; set; }
        public CountriesEnum Countries { get; set; }
        public string Depscription { get; set; }
        public DateTime Birth { get; set; }
        public LifeStatus LifeStatus { get; set; }
    }
}
