using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities.Reference
{
    public class CountingEntitity: RelationEntity
    {
        public string ParentId { get; set; } = null!;
        public virtual object Parent { get; set; } = null!;
        public int ViewCount { get;set; }
        public float Rating { get; set; }
        public int NumberOfVisit { get; set; }
        public string? Description { get;set; } 

        public virtual ICollection<object>? FacetEntity { get; set; }
        public virtual ICollection<object>? FacetEntity1 { get; set;}

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
