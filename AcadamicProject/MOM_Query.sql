--------------DataBase And Table Creation

CREATE DATABASE MOM_DB;
GO

USE MOM_DB;
GO

CREATE TABLE MOM_MeetingType (
    MeetingTypeID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingTypeName NVARCHAR(100) NOT NULL,
    Remarks NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT UQ_MOM_MeetingType UNIQUE (MeetingTypeName)
);

CREATE TABLE MOM_Department (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT UQ_MOM_Department UNIQUE (DepartmentName)
);

CREATE TABLE MOM_MeetingVenue (
    MeetingVenueID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingVenueName NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT UQ_MOM_MeetingVenue UNIQUE (MeetingVenueName)
);

CREATE TABLE MOM_Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentID INT NOT NULL,
    StaffName NVARCHAR(50) NOT NULL,
    MobileNo NVARCHAR(20) NOT NULL,
    EmailAddress NVARCHAR(50) NOT NULL,
    Remarks NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT UQ_MOM_Staff_Email UNIQUE (EmailAddress),
    CONSTRAINT FK_MOM_Staff_Department 
        FOREIGN KEY (DepartmentID) REFERENCES MOM_Department(DepartmentID)
);

CREATE TABLE MOM_Meetings (
    MeetingID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingDate DATETIME NOT NULL,
    MeetingVenueID INT NOT NULL,
    MeetingTypeID INT NOT NULL,
    DepartmentID INT NOT NULL,
    MeetingDescription NVARCHAR(250) NULL,
    DocumentPath NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,
    IsCancelled BIT NULL,
    CancellationDateTime DATETIME NULL,
    CancellationReason NVARCHAR(250) NULL,

    CONSTRAINT FK_MOM_Meetings_Venue 
        FOREIGN KEY (MeetingVenueID) REFERENCES MOM_MeetingVenue(MeetingVenueID),

    CONSTRAINT FK_MOM_Meetings_Type 
        FOREIGN KEY (MeetingTypeID) REFERENCES MOM_MeetingType(MeetingTypeID),

    CONSTRAINT FK_MOM_Meetings_Department 
        FOREIGN KEY (DepartmentID) REFERENCES MOM_Department(DepartmentID)
);

CREATE TABLE MOM_MeetingMember (
    MeetingMemberID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingID INT NOT NULL,
    StaffID INT NOT NULL,
    IsPresent BIT NOT NULL,
    Remarks NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT FK_MOM_MeetingMember_Meeting 
        FOREIGN KEY (MeetingID) REFERENCES MOM_Meetings(MeetingID),

    CONSTRAINT FK_MOM_MeetingMember_Staff 
        FOREIGN KEY (StaffID) REFERENCES MOM_Staff(StaffID),

    CONSTRAINT UQ_MOM_MeetingMember UNIQUE (MeetingID, StaffID)
);

--------------------------------------------------------------------


------Stored Procedure ------------

--MOM_MeetingType - Stored Procedures

CREATE OR ALTER PROCEDURE PR_MOM_MeetingType_SelectAll
AS
BEGIN
    SELECT
        MeetingTypeID,
        MeetingTypeName,
        Remarks,
        Created,
        Modified
    FROM MOM_MeetingType
    ORDER BY MeetingTypeName
END
----------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingType_SelectByPK
    @MeetingTypeID INT
AS
BEGIN
    SELECT *
    FROM MOM_MeetingType
    WHERE MeetingTypeID = @MeetingTypeID
END
---------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingType_Insert
    @MeetingTypeName NVARCHAR(100),
    @Remarks NVARCHAR(100),
    @Modified DATETIME
AS
BEGIN
    INSERT INTO MOM_MeetingType
    (MeetingTypeName, Remarks, Modified)
    VALUES
    (@MeetingTypeName, @Remarks, @Modified)
END
-----------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingType_UpdateByPK
    @MeetingTypeID INT,
    @MeetingTypeName NVARCHAR(100),
    @Remarks NVARCHAR(100),
    @Modified DATETIME
AS
BEGIN
    UPDATE MOM_MeetingType
    SET MeetingTypeName = @MeetingTypeName,
        Remarks = @Remarks,
        Modified = @Modified
    WHERE MeetingTypeID = @MeetingTypeID
END
------------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingType_DeleteByPK
    @MeetingTypeID INT
AS
BEGIN
    DELETE FROM MOM_MeetingType
    WHERE MeetingTypeID = @MeetingTypeID
END
------------------------------------------------

------------MOM_Department – Stored Procedures

CREATE OR ALTER PROCEDURE PR_MOM_Department_SelectAll
AS
BEGIN
    SELECT
        DepartmentID,
        DepartmentName,
        Created,
        Modified
    FROM MOM_Department
    ORDER BY DepartmentName
END
--------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_Department_Insert
    @DepartmentName NVARCHAR(100),
    @Modified DATETIME
AS
BEGIN
    INSERT INTO MOM_Department
    (DepartmentName, Modified)
    VALUES
    (@DepartmentName, @Modified)
END
-----------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_Department_UpdateByPK
    @DepartmentID INT,
    @DepartmentName NVARCHAR(100),
    @Modified DATETIME
AS
BEGIN
    UPDATE MOM_Department
    SET DepartmentName = @DepartmentName,
        Modified = @Modified
    WHERE DepartmentID = @DepartmentID
END
--------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_Department_DeleteByPK
    @DepartmentID INT
AS
BEGIN
    DELETE FROM MOM_Department
    WHERE DepartmentID = @DepartmentID
END
-------------------------------------------

-------------TABLE 3: MOM_MeetingVenue

CREATE OR ALTER PROCEDURE PR_MOM_MeetingVenue_SelectAll
AS
BEGIN
    SELECT
        MeetingVenueID,
        MeetingVenueName,
        Created,
        Modified
    FROM MOM_MeetingVenue
    ORDER BY MeetingVenueName
END

------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_MeetingVenue_SelectByPK
    @MeetingVenueID INT
AS
BEGIN
    SELECT *
    FROM MOM_MeetingVenue
    WHERE MeetingVenueID = @MeetingVenueID
END

-------------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingVenue_Insert
    @MeetingVenueName NVARCHAR(100),
    @Modified DATETIME
AS
BEGIN
    INSERT INTO MOM_MeetingVenue
    (MeetingVenueName, Modified)
    VALUES
    (@MeetingVenueName, @Modified)
END
----------------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingVenue_UpdateByPK
    @MeetingVenueID INT,
    @MeetingVenueName NVARCHAR(100),
    @Modified DATETIME
AS
BEGIN
    UPDATE MOM_MeetingVenue
    SET MeetingVenueName = @MeetingVenueName,
        Modified = @Modified
    WHERE MeetingVenueID = @MeetingVenueID
END
--------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_MeetingVenue_DeleteByPK
    @MeetingVenueID INT
AS
BEGIN
    DELETE FROM MOM_MeetingVenue
    WHERE MeetingVenueID = @MeetingVenueID
END
---------------------------------------------
----------TABLE 4: MOM_Staff

CREATE OR ALTER PROCEDURE PR_MOM_Staff_SelectAll
AS
BEGIN
    SELECT
        S.StaffID,
        S.StaffName,
        S.MobileNo,
        S.EmailAddress,
        D.DepartmentName,
        S.Created,
        S.Modified
    FROM MOM_Staff S
    INNER JOIN MOM_Department D
        ON S.DepartmentID = D.DepartmentID
    ORDER BY S.StaffName
END
--------------------
CREATE OR ALTER PROCEDURE PR_MOM_Staff_SelectByPK
    @StaffID INT
AS
BEGIN
    SELECT *
    FROM MOM_Staff
    WHERE StaffID = @StaffID
END
-------------------------
CREATE OR ALTER PROCEDURE PR_MOM_Staff_Insert
    @DepartmentID INT,
    @StaffName NVARCHAR(50),
    @MobileNo NVARCHAR(20),
    @EmailAddress NVARCHAR(50),
    @Remarks NVARCHAR(250),
    @Modified DATETIME
AS
BEGIN
    INSERT INTO MOM_Staff
    (DepartmentID, StaffName, MobileNo, EmailAddress, Remarks, Modified)
    VALUES
    (@DepartmentID, @StaffName, @MobileNo, @EmailAddress, @Remarks, @Modified)
END
--------------------------
CREATE OR ALTER PROCEDURE PR_MOM_Staff_UpdateByPK
    @StaffID INT,
    @DepartmentID INT,
    @StaffName NVARCHAR(50),
    @MobileNo NVARCHAR(20),
    @EmailAddress NVARCHAR(50),
    @Remarks NVARCHAR(250),
    @Modified DATETIME
AS
BEGIN
    UPDATE MOM_Staff
    SET DepartmentID = @DepartmentID,
        StaffName = @StaffName,
        MobileNo = @MobileNo,
        EmailAddress = @EmailAddress,
        Remarks = @Remarks,
        Modified = @Modified
    WHERE StaffID = @StaffID
END
-----------------------------------
CREATE OR ALTER PROCEDURE PR_MOM_Staff_DeleteByPK
    @StaffID INT
AS
BEGIN
    DELETE FROM MOM_Staff
    WHERE StaffID = @StaffID
END
-----------------------------------------
--TABLE 5: MOM_Meetings

CREATE OR ALTER PROCEDURE PR_MOM_Meetings_SelectAll
AS
BEGIN
    SELECT
        M.MeetingID,
        M.MeetingDate,
        MT.MeetingTypeName,
        MV.MeetingVenueName,
        D.DepartmentName,
        M.IsCancelled
    FROM MOM_Meetings M
    INNER JOIN MOM_MeetingType MT ON M.MeetingTypeID = MT.MeetingTypeID
    INNER JOIN MOM_MeetingVenue MV ON M.MeetingVenueID = MV.MeetingVenueID
    INNER JOIN MOM_Department D ON M.DepartmentID = D.DepartmentID
    ORDER BY M.MeetingDate DESC
END

-------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_Meetings_SelectByPK
    @MeetingID INT
AS
BEGIN
    SELECT *
    FROM MOM_Meetings
    WHERE MeetingID = @MeetingID
END

-------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_Meetings_Insert
    @MeetingDate DATETIME,
    @MeetingVenueID INT,
    @MeetingTypeID INT,
    @DepartmentID INT,
    @MeetingDescription NVARCHAR(250),
    @DocumentPath NVARCHAR(250),
    @Modified DATETIME
AS
BEGIN
    INSERT INTO MOM_Meetings
    (MeetingDate, MeetingVenueID, MeetingTypeID, DepartmentID,
     MeetingDescription, DocumentPath, Modified)
    VALUES
    (@MeetingDate, @MeetingVenueID, @MeetingTypeID, @DepartmentID,
     @MeetingDescription, @DocumentPath, @Modified)
END

-------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_Meetings_UpdateByPK
    @MeetingID INT,
    @MeetingDate DATETIME,
    @MeetingVenueID INT,
    @MeetingTypeID INT,
    @DepartmentID INT,
    @MeetingDescription NVARCHAR(250),
    @DocumentPath NVARCHAR(250),
    @Modified DATETIME
AS
BEGIN
    UPDATE MOM_Meetings
    SET MeetingDate = @MeetingDate,
        MeetingVenueID = @MeetingVenueID,
        MeetingTypeID = @MeetingTypeID,
        DepartmentID = @DepartmentID,
        MeetingDescription = @MeetingDescription,
        DocumentPath = @DocumentPath,
        Modified = @Modified
    WHERE MeetingID = @MeetingID
END
--------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_Meetings_DeleteByPK
    @MeetingID INT
AS
BEGIN
    DELETE FROM MOM_Meetings
    WHERE MeetingID = @MeetingID
END

---------------------------------------------

--TABLE 6: MOM_MeetingMember

CREATE OR ALTER PROCEDURE PR_MOM_MeetingMember_SelectAll
AS
BEGIN
    SELECT
        MM.MeetingMemberID,
        M.MeetingDate,
        S.StaffName,
        MM.IsPresent,
        MM.Remarks
    FROM MOM_MeetingMember MM
    INNER JOIN MOM_Meetings M ON MM.MeetingID = M.MeetingID
    INNER JOIN MOM_Staff S ON MM.StaffID = S.StaffID
    ORDER BY M.MeetingDate DESC, S.StaffName
END

------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_MeetingMember_SelectByPK
    @MeetingMemberID INT
AS
BEGIN
    SELECT *
    FROM MOM_MeetingMember
    WHERE MeetingMemberID = @MeetingMemberID
END

------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_MeetingMember_Insert
    @MeetingID INT,
    @StaffID INT,
    @IsPresent BIT,
    @Remarks NVARCHAR(250),
    @Modified DATETIME
AS
BEGIN
    INSERT INTO MOM_MeetingMember
    (MeetingID, StaffID, IsPresent, Remarks, Modified)
    VALUES
    (@MeetingID, @StaffID, @IsPresent, @Remarks, @Modified)
END

-------------------------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_MeetingMember_UpdateByPK
    @MeetingMemberID INT,
    @MeetingID INT,
    @StaffID INT,
    @IsPresent BIT,
    @Remarks NVARCHAR(250),
    @Modified DATETIME
AS
BEGIN
    UPDATE MOM_MeetingMember
    SET MeetingID = @MeetingID,
        StaffID = @StaffID,
        IsPresent = @IsPresent,
        Remarks = @Remarks,
        Modified = @Modified
    WHERE MeetingMemberID = @MeetingMemberID
END

------------------------------------------------------

CREATE OR ALTER PROCEDURE PR_MOM_MeetingMember_DeleteByPK
    @MeetingMemberID INT
AS
BEGIN
    DELETE FROM MOM_MeetingMember
    WHERE MeetingMemberID = @MeetingMemberID
END

-------------------------------------------------------



