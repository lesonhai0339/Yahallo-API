using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Enums.MangaEnums
{
    public enum MangaEnum
    {
    }
    /// <summary>
    /// Represents the status of the manga
    /// </summary>
    public enum MangaStatus
    {
        /// <summary>
        /// The manga is ongoing.
        /// </summary>
        Active = 1,

        /// <summary>
        /// The manga has been paused.
        /// </summary>
        Paused = 2,

        /// <summary>
        /// The manga has been finished.
        /// </summary>
        Finished = 3,
    }
    /// <summary>
    /// Represents the type of the manga
    /// </summary>
    public enum MangaType
    {
        /// <summary>
        /// Only one chapter
        /// </summary>
        Oneshot = 1,
        /// <summary>
        /// Multiple Chapter
        /// </summary>
        Series = 2,
        /// <summary>
        /// Non-professional author
        /// </summary>
        Dojinshi = 3,
    }
    /// <summary>
    ///  Users need a certain level to access or use coin to unlock manga
    /// </summary>
    public enum MangaLevel
    {
        /// <summary>
        /// Non-limit
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Lv2 - Lv4
        /// </summary>
        Pro = 2,
        /// <summary>
        /// Lv5 - Lv7
        /// </summary>
        Vip = 3,
        /// <summary>
        /// Lv8 - Lv9
        /// </summary>
        Master = 4,
    }
    /// <summary>
    /// Represents the type of the comment for manga or chapter
    /// </summary>
    public enum CommentType
    {
        Manga = 1,
        Chapter = 2,
        Blog = 3,
    }

}
