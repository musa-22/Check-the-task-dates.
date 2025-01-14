using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reminder.Model
{
    public class Details
    {

        public int Id { get; set; }

        public string Goal { get; set; }


        public DateTime startData { get; set; } 

        public DateTime endData { get; set; }


        public int? leftDays { get; set; }


        public int? totalDay { get; set; }


      
    }
}
