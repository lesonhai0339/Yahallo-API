using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Enums.Base
{
    /// <summary>
    /// Identify whether the image is for a user or for a manga.
    /// </summary>
    public enum TypeImage
    {
        /// <summary>
        /// Image for user avatar
        /// </summary>
        User = 1,
        /// <summary>
        /// image for manga image
        /// </summary>
        Manga = 2,
        /// <summary>
        /// image for chapter image
        /// </summary>
        Chapter = 3,
    }
    public enum LifeStatus
    {
        Alive = 1,
        Dead = 2,
    }
    public enum CommonStatus
    {
        Active = 1,
        Stopped = 2,
        Locked = 3,
        Hidden = 4,
    }
}
