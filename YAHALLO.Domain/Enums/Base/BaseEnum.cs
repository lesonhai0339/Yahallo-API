using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    #region Assign function for enums
//https://stackoverflow.com/questions/49590253/be-able-to-call-a-function-from-an-enum-c-sharp
//    void Function1(int val)
//    {
//        ...
//}
//    void Function2(int val)
//    {
//        ...
//}
//    void Function3(int val)
//    {
//        ...
//}

//    static readonly IDictionary<MyEnumType, Action<int>> MyEnumToAction = new Dictionary<MyEnumType, Action<int>>
//    {
//        [first_function] = Function1,
//        [second_function] = Function2,
//        [thrird_function] = Function3
//    };
//    MyEnumToAction[myEnumValue] (myIntArgument);

    #endregion
}
