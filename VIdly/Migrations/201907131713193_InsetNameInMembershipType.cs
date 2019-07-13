namespace VIdly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsetNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay as You Go' where DurationInMonths = 0");
            Sql("UPDATE MembershipTypes SET Name='Monthly' where DurationInMonths = 1");
            Sql("UPDATE MembershipTypes SET Name='Quaterly' where DurationInMonths = 3");
            Sql("UPDATE MembershipTypes SET Name='Yearly' where DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}
