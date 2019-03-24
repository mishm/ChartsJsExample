using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChartsExample.Models
{
    public class StackedViewModel
    {
        public StackedViewModel()
        {
            Stacks = new List<Stack>();
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public List<Stack> Stacks { get; set; }
    }

    public class Stack
    {
        public Stack()
        {
            LstData = new List<SingleBarViewModel>();
        }

        public string StackedBar { get; set; }
        public List<SingleBarViewModel> LstData { get; set; }
    }
}
