/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[BasicPay]
      ,[Start_Date]
      ,[Gender]
      ,[Phone]
      ,[Address]
      ,[Department]
      ,[Deductions]
      ,[Taxable]
      ,[IncomeTax]
      ,[NetPay]
  FROM [EmpPayrollMVC].[dbo].[ModelsEmployee]

  insert into ModelsEmployee (Name,BasicPay,Start_Date,Gender,Phone,Address,Department,Deductions,Taxable,IncomeTax,NetPay)
  values('Shweta',50000,'2022-11-26','F',9876543210,'Satara','Developer',500,200,200,45000)

  select *from ModelsEmployee