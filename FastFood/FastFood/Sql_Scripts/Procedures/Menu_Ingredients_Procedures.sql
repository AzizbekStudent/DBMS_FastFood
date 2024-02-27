-- Menu_Ingredients table
-- Students ID: 00013836, 00014725, 00014896

-- Get All
Go
Create or Alter Procedure p_Menu_Ingredients_Get_All
As
Begin
	Select e.*, m.meal_title, i.Title from Menu_Ingredients e join menu m 
		on e.meal_ID = m.meal_ID join Ingredients i
		on e.ingredient_ID = i.ingredient_ID
End

-- Get By Id
go
Create or Alter Procedure p_Menu_Ingredients_Get_By_Id
    @mealID Int
As
Begin
    Select * From Menu_Ingredients Where meal_ID = @mealID
End

-- Create
Go
Create or Alter Procedure p_Menu_Ingredients_Insert
    @mealID Int,
    @ingredientID Int
As
Begin
    Insert Into Menu_Ingredients (meal_ID, ingredient_ID)
    Values (@mealID, @ingredientID)
End

-- Update
Go
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
End

-- Delete
go
Create or Alter Procedure p_Menu_Ingredients_Delete
    @mealID Int,
    @ingredientID Int
As
Begin
    Delete From Menu_Ingredients Where meal_ID = @mealID AND ingredient_ID = @ingredientID
End 
