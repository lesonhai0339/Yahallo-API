using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.CountingEnums;

namespace YAHALLO.Domain.Entities.Reference
{
    public class CountingEntitity : RelationEntity
    {
        private string _parentId { get; set; } = null!;
        public string ParentId
        {
            get { return _parentId; }   
            set 
            {
                if(MangaId != null)
                {
                    _parentId = MangaId;
                }
                else if(ChapterId != null)
                {
                    _parentId = ChapterId;
                }
                else if(CommentId != null)
                {
                    _parentId = CommentId;
                }
                else if(BlogId != null)
                {
                    _parentId = BlogId!;
                }
                else
                {
                    _parentId = Guid.NewGuid().ToString().Substring(0, 10);
                }
            }
        }
        public CountingEnumType Type { get; set; }
        public int ViewCount { get;set; }
        public float Rating { get; set; }
        public int NumberOfVisit { get; set; }
        public string? Description { get;set; }
        private string? _userVisit;
        public string? UserVisit
        {
            get { return _userVisit; }
            set
            {
                if (value != null)
                {
                    SetUserVisit(string.Join(",", value));
                }
            }
        }

        public string? MangaId { get;set; } 
        public virtual MangaEntity? Manga { get; set; } 
        public string? ChapterId { get; set; }
        public virtual ChapterEntity? Chapter { get; set; }
        public string? CommentId { get; set; }
        public virtual CommentEntity? Comment { get; set; }
        public string? BlogId { get; set; }
        public virtual BlogEntity? Blog { get; set; }

        private void SetUserVisit(string idUser)
        {
            _userVisit = idUser;
        }
        public void UpdateViewCount(int newCount)
        {
            this.ViewCount += newCount;    
        }
        public void UpdateRating(float newRating)
        {
            this.Rating = ((float)this.Rating * NumberOfVisit) + newRating / (NumberOfVisit + 1);
        }
        public void UpdateRating(List<float> newRating, int newNumberOfVisit)
        {
            float sum= newRating.Sum();
            this.Rating = ((float)this.Rating * NumberOfVisit) + sum / (NumberOfVisit + newNumberOfVisit);
        }
    }
}
