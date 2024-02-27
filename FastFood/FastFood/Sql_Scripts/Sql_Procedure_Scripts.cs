namespace FastFood.Sql_Scripts
{
    public static class Sql_Procedure_Scripts
    {
        // SQL statements for table
        // Employee
        public const string sp_Employee_Get_All = @"
Create or Alter Procedure p_Employee_Get_All
As
Begin
	Select employee_ID, FName, LName, Telephone, Job, Age, Salary, HireDate, Image, FullTime
	From Employee
End";

        public const string sp_Employee_Insert = @"
Create or Alter Procedure p_Employee_Insert
    @FName varchar(255),
    @LName varchar(255),
    @Telephone varchar(20),
    @Job varchar(255),
    @Age Int,
    @Salary Decimal(10, 2),
    @HireDate DateTime,
    @Image VarBinary(MAX),
    @FullTime BIT
As
Begin
    If @Job Not In ('admin', 'cook', 'cashier')
    Begin 
        Raiserror('Invalid job type. Job type might consist of these: admin, cook, and cashier.', 15, 1)
        Return
    End

    Insert Into Employee (FName, LName, Telephone, Job, Age, Salary, HireDate, Image, FullTime)
    Values (@FName, @LName, @Telephone, @Job, @Age, @Salary, @HireDate, @Image, @FullTime)
End";

        public const string sp_Employee_Update = @"
Create or Alter Procedure p_Employee_Update
    @employeeID Int,
    @FName varchar(255),
    @LName varchar(255),
    @Telephone varchar(20),
    @Job varchar(255),
    @Age Int,
    @Salary Decimal(10, 2),
    @HireDate DateTime,
    @Image VarBinary(MAX),
    @FullTime BIT
As
Begin
    Update Employee
    Set FName = @FName,
        LName = @LName,
        Telephone = @Telephone,
        Job = @Job,
        Age = @Age,
        Salary = @Salary,
        HireDate = @HireDate,
        Image = @Image,
        FullTime = @FullTime
    Where employee_ID = @employeeID
End";

        public const string sp_Employee_Delete = @"
Create or Alter Procedure p_Employee_Delete
    @employeeID Int
As
Begin
    Delete From Employee Where employee_ID = @employeeID
End";

        public const string sp_Employee_Get_By_Id = @"
Create or Alter Procedure p_Employee_Get_ByID
    @employeeID int
As
Begin
    Select employee_ID, FName, LName, Telephone, Job, Age, Salary, HireDate, Image, FullTime
    From Employee
    Where employee_ID = @employeeID
End";

        // SQL statements for table
        // Ingredients
        public const string sp_Ingredients_Get_All = @"";

        public const string sp_Ingredients_Get_By_Id = @"";

        public const string sp_Ingredients_Insert = @"";

        public const string sp_Ingredients_Update = @"";

        public const string sp_Ingredients_Delete = @"";



        // SQL statements for table
        // Menu
        public const string sp_Menu_Get_All = @"";

        public const string sp_Menu_Get_By_Id = @"";

        public const string sp_Menu_Insert = @"";

        public const string sp_Menu_Update = @"";

        public const string sp_Menu_Delete = @"";


        // SQL statements for table
        // Orders
        public const string sp_Order_Get_All = @"";

        public const string sp_Order_Get_By_Id = @"";

        public const string sp_Order_Insert = @"";

        public const string sp_Order_Update = @"";

        // SQL statements for table
        // Menu_Ingredients
        public const string sp_Menu_Ingredients_Get_All = @"";

        public const string sp_Menu_Ingredients_Get_By_Id = @"";

        public const string sp_Menu_Ingredients_Insert = @"";

        public const string sp_Menu_Ingredients_Delete = @"";
    }
}
