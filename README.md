CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId]
    ON [dbo].[AspNetRoleClaims]([RoleId] ASC);



CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);



CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);



CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);


CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);



CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [sex]                  NVARCHAR (MAX)     NULL,
    [firstName]            NVARCHAR (MAX)     NULL,
    [lastName]             NVARCHAR (MAX)     NULL,
    [birthDate]            NVARCHAR (MAX)     NULL,
    [levelAccess]          INT                NULL,
    [progress]             INT                NULL,
    [group]                NVARCHAR (MAX)     NULL,
    [subjectList]          NVARCHAR (MAX)     NULL,
    [subject]              NVARCHAR (MAX)     NULL,
    [groupList]            NVARCHAR (MAX)     NULL,
    [Discriminator]        NVARCHAR (MAX)     NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);



CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (450) NOT NULL,
    [Name]          NVARCHAR (450) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [Name] ASC),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);



CREATE TABLE [dbo].[Assignement] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [studentId]  INT            NOT NULL,
    [CourseName] NVARCHAR (MAX) NOT NULL,
    [Date]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Assignement] PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[Attendance] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [courseId]  INT            NOT NULL,
    [facultyId] INT            NOT NULL,
    [status]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[Course] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [teacherId]   INT            NOT NULL,
    [studentId]   INT            NOT NULL,
    [begin]       DATETIME2 (7)  NOT NULL,
    [end]         DATETIME2 (7)  NOT NULL,
    [courseName]  NVARCHAR (MAX) NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[Exam] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]  INT            NOT NULL,
    [CourseName] NVARCHAR (MAX) NOT NULL,
    [Date]       DATETIME2 (7)  NOT NULL,
    [Grade]      FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Fee] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [facultyId]   INT            NOT NULL,
    [amount]      INT            NOT NULL,
    [deadline]    DATETIME2 (7)  NOT NULL,
    [description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Fee] PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[Result] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]  INT            NOT NULL,
    [CourseName] NVARCHAR (MAX) NOT NULL,
    [Average]    FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Profile] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [firstName]     NVARCHAR (MAX) NOT NULL,
    [lastName]      NVARCHAR (MAX) NOT NULL,
    [birthDate]     NVARCHAR (MAX) NOT NULL,
    [sex]           NVARCHAR (MAX) NOT NULL,
    [userName]      NVARCHAR (MAX) NOT NULL,
    [emailAdress]   NVARCHAR (MAX) NOT NULL,
    [password]      NVARCHAR (MAX) NOT NULL,
    [Discriminator] NVARCHAR (MAX) NOT NULL,
    [group]         NVARCHAR (MAX) NULL,
    [progress]      INT            NULL,
    [subjectList]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED ([id] ASC)
);

