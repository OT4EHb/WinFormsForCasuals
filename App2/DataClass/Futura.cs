using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DataClass
{
    [TableName("futura")]
    internal class Futura
    {
        [IsPrimaryKey]
        [ColumnName("ID")]
        [DisplayName("ID")]
        public uint ID { get; set; } = 0;

        [ForeignKey("client", "Name")]
        [ColumnName("IDClient")]
        [DisplayName("Имя клиента")]
        public uint IDClient { get; set; } = 0;

        [ColumnName("DateV")]
        [DisplayName("Дата чего-то")]
        public DateTime DateV { get; set; } = DateTime.Now;

        [ColumnName("TotalSum")]
        [DisplayName("Итоговая стоимость")]
        public uint TotalSum { get; set; } = 0;
    }
}
