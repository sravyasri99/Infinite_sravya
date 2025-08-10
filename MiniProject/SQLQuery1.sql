create database miniproject1

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Age INT,
    Gender CHAR(1),
    Email VARCHAR(100)
);


-- Train Details
CREATE TABLE Trains (
    TrainNo INT,
    TrainName VARCHAR(100),
    Source VARCHAR(50),
    Destination VARCHAR(50),
    Class VARCHAR(20), -- Sleeper, 2nd AC, 3rd AC
    Availability INT,
    Cost DECIMAL(10,2),
    PRIMARY KEY (TrainNo, Class)
);

CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1000,1),
    CustomerID INT,
    TrainNo INT,
    Class VARCHAR(20),
    DateOfJourney DATE,
    SeatsBooked INT,
    TotalCost DECIMAL(10,2),
    BookingDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (TrainNo, Class) REFERENCES Trains(TrainNo, Class)
);



-- Cancellation Table
CREATE TABLE Cancellations (
    CancellationID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT UNIQUE,
    CancellationDate DATE,
    RefundAmount DECIMAL(10,2),
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID)
);


CREATE TABLE Users (
    UserId VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50),
    Role VARCHAR(10) CHECK (Role IN ('Admin', 'Customer'))
);

CREATE OR ALTER PROCEDURE ReserveTicket
    @CustomerID INT,
    @CustomerName VARCHAR(100),
    @TrainNo INT,
    @Class VARCHAR(20),
    @DateOfJourney DATE,
    @SeatsBooked INT,
    @ReservationID INT OUTPUT  --  Add this line
AS
BEGIN
    DECLARE @Cost DECIMAL(10,2),
            @TotalCost DECIMAL(10,2)

    SELECT @Cost = Cost FROM Trains WHERE TrainNo = @TrainNo AND Class = @Class
    SET @TotalCost = @SeatsBooked * @Cost

    IF NOT EXISTS (SELECT 1 FROM Customers WHERE CustomerID = @CustomerID)
    BEGIN
        INSERT INTO Customers (CustomerID, Name) VALUES (@CustomerID, @CustomerName)
    END

    INSERT INTO Reservations (
        CustomerID, 
        CustomerName, 
        TrainNo, 
        Class, 
        DateOfJourney, 
        SeatsBooked, 
        TotalCost, 
        BookingDate
    )
    VALUES (
        @CustomerID, 
        @CustomerName, 
        @TrainNo, 
        @Class, 
        @DateOfJourney, 
        @SeatsBooked, 
        @TotalCost, 
        GETDATE()
    )

    -- Capture the newly inserted ReservationID
    SET @ReservationID = SCOPE_IDENTITY()

    UPDATE Trains
    SET Availability = Availability - @SeatsBooked
    WHERE TrainNo = @TrainNo AND Class = @Class
END




CREATE OR ALTER PROCEDURE CancelTicket
    @ReservationID INT,
    @SeatsToCancel INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE 
        @TotalSeats INT, 
        @TotalCost DECIMAL(10,2), 
        @TrainNo INT, 
        @Class VARCHAR(20), 
        @DateOfJourney DATE,
        @RefundAmount DECIMAL(10,2), 
        @NewStatus VARCHAR(20), 
        @RefundRate FLOAT, 
        @DaysBeforeJourney INT;

    -- Fetch reservation details
    SELECT 
        @TotalSeats = SeatsBooked,
        @TotalCost = TotalCost,
        @TrainNo = TrainNo,
        @Class = Class,
        @DateOfJourney = DateOfJourney
    FROM Reservations
    WHERE ReservationID = @ReservationID;

    -- Validation: Cannot cancel more seats than booked
    IF @SeatsToCancel > @TotalSeats
    BEGIN
        RAISERROR('Cannot cancel more seats than booked.', 16, 1);
        RETURN;
    END

    -- Calculate days before journey
    SET @DaysBeforeJourney = DATEDIFF(DAY, GETDATE(), @DateOfJourney);

    -- Determine refund rate
    IF @DaysBeforeJourney >= 2
        SET @RefundRate = 0.80;
    ELSE
        SET @RefundRate = 0.50;

    -- Calculate refund amount
    SET @RefundAmount = (@TotalCost / @TotalSeats) * @SeatsToCancel * @RefundRate;

    -- Insert cancellation record
    INSERT INTO Cancellations (
        ReservationID, 
        SeatsCancelled, 
        RefundAmount, 
        CancellationDate
    )
    VALUES (
        @ReservationID, 
        @SeatsToCancel, 
        @RefundAmount, 
        GETDATE()
    );

    -- Update reservation status and seats
    IF @SeatsToCancel = @TotalSeats
    BEGIN
        SET @NewStatus = 'Cancelled';
        UPDATE Reservations
        SET Status = @NewStatus
        WHERE ReservationID = @ReservationID;
    END
    ELSE
    BEGIN
        SET @NewStatus = 'Partially Cancelled';
        UPDATE Reservations
        SET SeatsBooked = SeatsBooked - @SeatsToCancel,
            Status = @NewStatus
        WHERE ReservationID = @ReservationID;
    END

    -- Restore seat availability in Trains
    UPDATE Trains
    SET Availability = Availability + @SeatsToCancel
    WHERE TrainNo = @TrainNo AND Class = @Class;

    -- Final output
    SELECT 
        @RefundRate * 100 AS RefundRatePercent,
        @RefundAmount AS RefundAmount,
        @NewStatus AS NewStatus;
END






-- Customers
INSERT INTO Customers (Name, Age, Gender, Email) VALUES 
('Arjun Mehta', 30, 'M', 'arjun.mehta@gmail.com'),
('Priya Reddy', 28, 'F', 'priya.reddy@yahoo.com');

-- Trains (Class-wise entries)
INSERT INTO Trains (TrainNo, TrainName, Source, Destination, Class, Availability, Cost) VALUES 
(101, 'Vande Bharat', 'Hyderabad', 'Chennai', 'Sleeper', 50, 500),
(101, 'Vande Bharat', 'Hyderabad', 'Chennai', '2nd AC', 30, 850),
(101, 'Vande Bharat', 'Hyderabad', 'Chennai', '3rd AC', 40, 700);

-- Users
INSERT INTO Users (UserId, Password, Role) VALUES 
('admin1', 'admin123', 'Admin'),
('cust1', 'cust123', 'Customer');

SELECT * FROM Reservations
SELECT * FROM Trains

ALTER TABLE Reservations ADD CustomerName VARCHAR(100);

ALTER TABLE Reservations
ADD Status VARCHAR(20) DEFAULT 'Confirmed';

ALTER TABLE Cancellations
ADD SeatsCancelled INT;

UPDATE Trains SET Availability = 50;

ALTER TABLE Trains ADD IsActive BIT DEFAULT 1;

UPDATE Trains SET IsActive = 1 WHERE IsActive IS NULL;
