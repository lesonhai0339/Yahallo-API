using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Common.Interfaces
{
    public class ResponeResult<T>
    {
        public ResponeResult() { }
        public ResponeResult(string? message) 
        {
            Message = message;
        }
        public ResponeResult(List<T>? entities) 
        {
            ListEntity = entities;
        }

        public ResponeResult(
            string? id,
            string? name,
            string? message,
            string? content,
            T? entity,
            List<T>? entities,
            IFormFile? file,
            List<IFormFile>? files
            ) 
        {
            Id = id;
            Name = name;
            Message = message;
            Content = content;
            Entity = entity;
            ListEntity = entities;
            File = file;
            ListFile = files;
        }
        public string? Id { get;set; }
        public string? Name { get;set; }
        public string? Message { get;set; }
        public string? Content { get;set; }
        public T? Entity { get;set; }
        public List<T>? ListEntity { get;set; }
        public IFormFile? File { get;set; }  
        public List<IFormFile>? ListFile { get;set; }
    }
}
