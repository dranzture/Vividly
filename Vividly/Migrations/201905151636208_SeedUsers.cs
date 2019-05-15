namespace Vividly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'715513e8-9bff-48d9-a832-0f9b36e21fb9', N'polat@vidly.com', 0, N'AOtrxFMGCodDRShVVCezjBrKdnqInzAN0rmD8Br8p6+Yl2VZhQmae1rcWcZHnEXZNw==', N'94770d21-e5d1-423b-b001-3173285f20ad', NULL, 0, 0, NULL, 1, 0, N'polat@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f9712e9-4d6c-4677-80af-da468856c1d0', N'admin@vidly.com', 0, N'AD9mSi79psqZkJeNtqw3yaWTEWE1v+Bs0LfGHU7N/CXauxOLx3rebVByucVt3Vus7Q==', N'7046f7fb-170f-4a31-a508-8284d433049c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'60170ac7-3ca9-4d8a-a892-3b03aa437b9b', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9f9712e9-4d6c-4677-80af-da468856c1d0', N'60170ac7-3ca9-4d8a-a892-3b03aa437b9b')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
