using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class User
    {
        public string Name { get; set; } = "";
        public System.DateOnly Date {  get; set; }

        public string City { get; set; } = "";
        public string Sex { get; set; } = "";
        public List<string> Sport { get; set; } = [];
        public User() {}

        public override string ToString()
        {
            string temp = (Name + '\n'
                + Date.ToString() + '\n'
                + City + '\n'
                + Sex + '\n');
            foreach (string i in Sport)
            {
                temp += i + '\n';
            }            
            return temp + '\n';
                
        }
    }
}
