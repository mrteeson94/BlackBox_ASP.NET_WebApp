namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            //1. scripts added from dbo.AspNetUsers (admin + guest account)  \ 1st 2 queries line 
            //2. Asp.NetRoles creates entity for admin roles such as 'CanManageMovies' \ 3rd query line
            //3. AspNetUserRoles assigns certain users to the .NetRoles (manager that can handle movies) in this context \ 4th query line

            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84bb2fb1-7c6d-4648-b0d7-823bf3265137', N'guest@blackbox.com', 0, N'AKkERTJBjAm5rkJtszB8LxFbKomaOq0O80H4AmFskISDRSbtzGDjxuC4p+dgJnNxJg==', N'0b5c1bf5-d4f0-4908-8597-d727d71819a7', NULL, 0, 0, NULL, 1, 0, N'guest@blackbox.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec046a2e-647c-4470-96bf-2a5566f59770', N'admin@blackbox.com', 0, N'AMCQQm91/Pcc8cCTvayrn5xt611TDMNgutz+E1WcOfXvEJQ6D9OqnypLHUHwMjSZlw==', N'565b2cf0-d217-4cb5-b263-85c166af348f', NULL, 0, 0, NULL, 1, 0, N'admin@blackbox.com')
    
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd4fef8a2-fec0-4781-ac62-188924f39067', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec046a2e-647c-4470-96bf-2a5566f59770', N'd4fef8a2-fec0-4781-ac62-188924f39067')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
