using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.services
{
    public interface IDayOffService :IService<dayoff>
    {
        List<dayoff> ListerDayOff(int resourceId);
        dayoff getDayOffById(int resourceId, int dayoffId);
        Boolean deleteDayOff(dayoff d);
        Boolean AccepterDayOff(dayoff d);
        List<dayoff> ListerDayOffHoldOn(int resourceId);


    }
}
