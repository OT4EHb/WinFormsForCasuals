using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DataClass
{
    [TableName("client")]
    [DisplayName("Клиенты")]
    internal class Client
    {
        [IsPrimaryKey]
        [ColumnName("ID")]
        [DisplayName("ID")]
        public uint Id { get; set; } = 0;

        [ColumnName("Name")]
        [DisplayName("Имя")]
        public string Name { get; set; } = "";

        [ColumnName("Adress")]
        [DisplayName("Адрес")]
        public string Adress { get; set; } = "";

        [ColumnName("Phone")]
        [DisplayName("Телефон")]
        public string Phone { get; set; } = "";
    }
}
