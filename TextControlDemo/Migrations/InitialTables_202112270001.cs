using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextControlDemo.Migrations
{
    [Migration(202112270001)]
    public class InitialTables_202112270001 : Migration
    {
        public override void Down()
        {
            Delete.Table("TxDocument");
        }

        public override void Up()
        {
            Create.Table("TxDocument")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(300)
                .WithColumn("UniqueId").AsGuid();
        }
    }
}
