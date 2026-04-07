using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DataClass
{
    [TableName("futura")]
    [DisplayName("Накладные")]
    internal class Futura
    {
        [IsPrimaryKey]
        [ColumnName("ID")]
        [DisplayName("ID")]
        public uint ID { get; set; } = 0;

        [ForeignKey("client", "Name")]
        [ColumnName("IDClient")]
        [DisplayName("ID клиента")]
        public uint IDClient { get; set; } = 0;

        [ColumnName("DateV")]
        [DisplayName("Дата")]
        public DateTime DateV { get; set; } = DateTime.Now;

        [ColumnName("TotalSum")]
        [DisplayName("Итоговая стоимость")]
        public uint TotalSum { get; set; } = 0;
    }
}
