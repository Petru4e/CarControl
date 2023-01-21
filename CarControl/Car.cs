using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarControl
{
    class Car
    {
       public int id { get; set; }
        private string number, model, comment, date_start, date_end, category;
        
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public string Date_Start
        {
            get { return date_start; }
            set { date_start = value; }
        }
        public string Date_End
        {
            get { return date_end; }
            set { date_end = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public Car() { }

        public Car(string number, string model, string comment, string date_start, string date_end, string category)
        {
            this.number = number;
            this.model = model;
            this.comment = comment;
            this.date_start = date_start;
            this.date_end = date_end;
            this.category = category;
        }
        

    }
}
