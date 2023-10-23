using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs
{ 
    /// <summary>
    /// Вспомогательный класс для общения с базой данных и создания глобалых переменных    
    /// </summary>
    internal class Helper
    {
        public static DateBase.KursContext db = new DateBase.KursContext();
        public static DateBase.User usersession;
    }
}
