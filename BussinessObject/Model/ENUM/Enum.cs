using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model.ENUM
{
    public enum UserRoleEnum
    {

    }
    public enum StatusEnum : short
    {
        inactive = 1,
        active = 2,
        inProcess = 3
    }

    public enum StatusKennel : short
    {
        emptyRoom = 0,
        validRom = 1,
    }
}
