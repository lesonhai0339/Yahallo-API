using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Enums.UserEnums
{
    public enum UserEnum
    {
    }
    /// <summary>
    /// Represents the status of a user
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// The user has normal status
        /// </summary>
        None = 1,
        /// <summary>
        /// The user has been banned
        /// </summary>
        Lock = 2,
    }
    /// <summary>
    /// User can level up when read chapter
    /// </summary>
    public enum UserLevel
    {
        /// <summary>
        /// When the account has been created
        /// </summary>
        One = 1,
        /// <summary>
        /// Read 100 Chapters
        /// </summary>
        Two = 2,
        /// <summary>
        /// Read 500 Chapters
        /// </summary>
        Three = 3,
        /// <summary>
        /// Read 1000 Chapters
        /// </summary>
        Four = 4,
        /// <summary>
        /// Read 2000 Chapters
        /// </summary>
        Five = 5,
        /// <summary>
        /// Read 3500 Chapters
        /// </summary>
        Six = 6,
        /// <summary>
        /// Read 5000 Chapters
        /// </summary>
        Seven = 7,
        /// <summary>
        /// Read 7000 Chapters
        /// </summary>
        Eight = 8,
        /// <summary>
        /// Read 10000 Chapters
        /// </summary>
        Nine = 9,
    }
}
