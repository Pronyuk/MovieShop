namespace MoviewShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Junior' FROM MembershipTypes WHERE MembershipTypes.Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Middle' FROM MembershipTypes WHERE MembershipTypes.Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Pro' FROM MembershipTypes WHERE MembershipTypes.Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Senior' FROM MembershipTypes WHERE MembershipTypes.Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
