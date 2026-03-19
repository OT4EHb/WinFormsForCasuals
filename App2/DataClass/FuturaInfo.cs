using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DataClass
{
    [TableName("futurainfo")]
    [DisplayName("Информация о накладных")]
    internal class FuturaInfo
    {
        [IsPrimaryKey]
        [ColumnName("ID")]
        [DisplayName("ID")]
        public uint ID { get; set; } = 0;

        [ForeignKey("futura", "ID")]
        [ColumnName("IDFutura")]
        [DisplayName("ID футуры")]
        public uint IDFutura { get; set; } = 0;

        [ForeignKey("product", "Name")]
        [ColumnName("IDProduct")]
        [DisplayName("Название продукта")]
        public uint IDProduct { get; set; } = 0;

        [ColumnName("Quantity")]
        [DisplayName("Количество")]
        public uint Quantity { get; set; } = 0;

        [ColumnName("Price")]
        [DisplayName("Цена")]
        public uint Price { get; set; } = 0;
    }
}
