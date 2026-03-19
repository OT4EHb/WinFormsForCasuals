namespace App2
{

    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute(string name) : Attribute
    {
        public string Name { get; } = name;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute(string name) : Attribute
    {
        public string Name { get; } = name;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IsPrimaryKeyAttribute : Attribute
    {
        public bool AutoIncrement { get; set; } = true;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute(string referenceTable, string displayColumn, string referenceColumn="ID") : Attribute
    {
        public string ReferenceTable { get; } = referenceTable;

        public string DisplayColumn { get; } = displayColumn;
        public string ReferenceColumn { get; } = referenceColumn;
    }
}