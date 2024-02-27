namespace FastFood.Sql_Scripts
{
    // Students ID: 00013836, 00014725, 00014896
    public static class Sql_Procedure_Scripts
    {
        // SQL statements for table
        // Employee
        public const string udp_GetAllEmployee = @"
Create or Alter Procedure udp_GetAllEmployee
As
Begin
	Select employee_ID, FName, LName, Telephone, Job, Age, Salary, HireDate, Image, FullTime
	From Employee
End";

        public const string p_Employee_Insert = @"
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

        public const string p_Employee_Update = @"
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

        public const string p_Employee_Delete = @"
Create or Alter Procedure p_Employee_Delete
    @employeeID Int
As
Begin
    Delete From Employee Where employee_ID = @employeeID
End";

        public const string p_Employee_Get_ByID = @"
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
        public const string sp_Ingredients_Get_All = @"
Create or Alter Procedure p_Ingredients_Get_All
As
Begin
	Select ingredient_ID, Title, Price, Amount_in_grams, Unit, IsForVegan, Image  
	From Ingredients
End";

        public const string sp_Ingredients_Get_By_Id = @"
Create or Alter Procedure p_Ingredients_Get_By_Id
    @ingredientID Int
As
Begin
    Select Title, Price, Amount_in_grams, Unit, IsForVegan, Image 
	From Ingredients Where ingredient_ID = @ingredientID
End";

        public const string sp_Ingredients_Insert = @"
Create or Alter Procedure p_Ingredients_Insert
    @Title Varchar(255),
    @Price Decimal(10, 2),
    @Amount_in_grams Int,
    @Unit Int,
    @IsForVegan BIT,
    @Image VarBinary(MAX)
As
Begin
    Insert Into Ingredients (Title, Price, Amount_in_grams, Unit, IsForVegan, Image)
    Values (@Title, @Price, @Amount_in_grams, @Unit, @IsForVegan, @Image)
End";

        public const string sp_Ingredients_Update = @"
Create or Alter Procedure p_Ingredients_Update
    @ingredientID Int,
    @Title Varchar(255),
    @Price Decimal(10, 2),
    @Amount_in_grams Int,
    @Unit Int,
    @IsForVegan BIT,
    @Image VarBinary(MAX)
As
Begin
    Update Ingredients
    Set Title = @Title,
        Price = @Price,
        Amount_in_grams = @Amount_in_grams,
        Unit = @Unit,
        IsForVegan = @IsForVegan,
        Image = @Image
    Where ingredient_ID = @ingredientID
End";

        public const string sp_Ingredients_Delete = @"
Create or Alter Procedure p_Ingredients_Delete
    @ingredientID Int
As
Begin
    Delete From Ingredients Where ingredient_ID = @ingredientID
End";



        // SQL statements for table
        // Menu
        public const string sp_Menu_Get_All = @"
Create or Alter Procedure p_Menu_Get_All
As
Begin
    Select meal_ID, meal_title, price, size, TimeToPrepare, Image, IsForVegan, created_Date 
    From Menu
End";

        public const string sp_Menu_Get_By_Id = @"
Create or Alter Procedure p_Menu_Get_By_Id
	@meal_ID int
As
Begin
	Select meal_ID, meal_title, price, size, TimeToPrepare, Image, IsForVegan, created_Date  
	From Menu Where meal_ID = @meal_ID
End";

        public const string sp_Menu_Insert = @"
Create or Alter Procedure p_Menu_Insert
    @meal_title VARCHAR(255),
    @price DECIMAL(10, 2),
    @size VARCHAR(7),
    @TimeToPrepare TIME,
    @Image VARBINARY(MAX),
    @IsForVegan BIT
As
Begin
    Insert Into Menu (meal_title, price, size, TimeToPrepare, Image, IsForVegan, created_Date)
    Values (@meal_title, @price, @size, @TimeToPrepare, @Image, @IsForVegan, GETDATE());
End";

        public const string sp_Menu_Update = @"
Create or Alter Procedure p_Menu_Update
    @meal_ID INT,
    @meal_title VARCHAR(255),
    @price DECIMAL(10, 2),
    @size VARCHAR(7),
    @TimeToPrepare TIME,
    @Image VARBINARY(MAX),
    @IsForVegan BIT
As
Begin
    Update Menu
    Set meal_title = @meal_title,
        price = @price,
        size = @size,
        TimeToPrepare = @TimeToPrepare,
        Image = @Image,
        IsForVegan = @IsForVegan
    Where meal_ID = @meal_ID
End";

        public const string sp_Menu_Delete = @"
Create or Alter Procedure p_Menu_Delete
    @meal_ID INT
As
Begin
    Delete From Menu Where meal_ID = @meal_ID
End";


        // SQL statements for table
        // Orders
        public const string sp_Order_Get_All = @"
Create or Alter Procedure p_Order_Get_All
As
Begin
	Select order_ID, OrderTime, DeliveryTime, PaymentStatus, Meal_ID, Amount, Total_Cost, Prepared_by 
	From Orders
End
";

        public const string sp_Order_Get_By_Id = @"
Create or Alter Procedure p_Order_Get_By_Id
    @OrderID Int
As
Begin
    Select order_ID, OrderTime, DeliveryTime, PaymentStatus, Meal_ID, Amount, Total_Cost, Prepared_by  
	From Orders Where order_ID = @OrderID
End";

        public const string sp_Order_Insert = @"
Create or Alter Procedure p_Order_Create
    @OrderTime DateTime,
    @DeliveryTime DateTime,
    @PaymentStatus BIT,
    @MealID Int,
    @Amount Int,
    @TotalCost Decimal(10, 2),
    @PreparedBy Int
As
Begin
    Insert Into Orders (OrderTime, DeliveryTime, PaymentStatus, Meal_ID, Amount, Total_Cost, Prepared_by)
    Values (@OrderTime, @DeliveryTime, @PaymentStatus, @MealID, @Amount, @TotalCost, @PreparedBy)
End";

        public const string sp_Order_Update = @"
Create or Alter Procedure p_Order_Update
    @OrderID Int,
    @OrderTime DateTime,
    @DeliveryTime DateTime,
    @PaymentStatus BIT,
    @MealID Int,
    @Amount Int,
    @TotalCost Decimal(10, 2),
    @PreparedBy Int
As
Begin
    If Exists (Select 1 From Orders Where order_ID = @OrderID)
    Begin
        Update Orders
        Set OrderTime = @OrderTime,
            DeliveryTime = @DeliveryTime,
            PaymentStatus = @PaymentStatus,
            Meal_ID = @MealID,
            Amount = @Amount,
            Total_Cost = @TotalCost,
            Prepared_by = @PreparedBy
        Where order_ID = @OrderID
    End
    Else
    Begin
        Raiserror('Order with ID = @OrderID does not exist.', 16, 1)
    End
End";

        public const string sp_Order_Delete = @"
Create or Alter Procedure p_Order_Delete
    @OrderID Int
As
Begin
    Delete From Orders Where order_ID = @OrderID
End ";

        // SQL statements for table
        // Menu_Ingredients
        public const string sp_Menu_Ingredients_Get_All = @"
Create or Alter Procedure p_Menu_Ingredients_Get_All
As
Begin
	Select e.*, m.meal_title, i.Title from Menu_Ingredients e join menu m 
		on e.meal_ID = m.meal_ID join Ingredients i
		on e.ingredient_ID = i.ingredient_ID
End";

        public const string sp_Menu_Ingredients_Get_By_Id = @"
Create or Alter Procedure p_Menu_Ingredients_Get_By_Id
    @mealID Int
As
Begin
    Select * From Menu_Ingredients Where meal_ID = @mealID
End";

        public const string sp_Menu_Ingredients_Insert = @"
Create or Alter Procedure p_Menu_Ingredients_Insert
    @mealID Int,
    @ingredientID Int
As
Begin
    Insert Into Menu_Ingredients (meal_ID, ingredient_ID)
    Values (@mealID, @ingredientID)
End";

        public const string sp_Menu_Ingredients_Update = @"
Create or Alter Procedure p_Menu_Ingredients_Update
    @mealID Int,
    @ingredientID Int,
    @oldMealID Int,
    @oldIngredientID Int
As
Begin
    Update Menu_Ingredients
    Set meal_ID = @mealID,
        ingredient_ID = @ingredientID
    Where meal_ID = @oldMealID AND ingredient_ID = @oldIngredientID
End";

        public const string sp_Menu_Ingredients_Delete = @"
Create or Alter Procedure p_Menu_Ingredients_Delete
    @mealID Int,
    @ingredientID Int
As
Begin
    Delete From Menu_Ingredients Where meal_ID = @mealID AND ingredient_ID = @ingredientID
End ";
    }
}
