using Assesment_SQLQuery8;
using System;
using System.Linq;

namespace Assessment_SQLQuery8
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AdvancedDBEntities())
            {
                while (true)
                {
                    Console.WriteLine("Choose a table to work with:");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Products");
                    Console.WriteLine("3. Orders");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice (1/2/3/4): ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                EmployeeMenu(db);
                                break;
                            case 2:
                                ProductsMenu(db);
                                break;
                            case 3:
                                OrdersMenu(db);
                                break;
                            case 4:
                                Console.WriteLine("Exiting the program.");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please select a valid option.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    Console.WriteLine("\n");
                }
            }
        }

        // Employee Table
        static void EmployeeMenu(AdvancedDBEntities db)
        {
            while (true)
            {
                Console.WriteLine("Employee Table:");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Read Employees");
                Console.WriteLine("3. Update Employee Salary");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice (1/2/3/4/5): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateEmployee(db);
                            break;
                        case 2:
                            ReadEmployees(db);
                            break;
                        case 3:
                            UpdateEmployeeSalary(db);
                            break;
                        case 4:
                            DeleteEmployee(db);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("\n");
            }
        }

        // Products Table
        static void ProductsMenu(AdvancedDBEntities db)
        {
            while (true)
            {
                Console.WriteLine("Products Table:");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Read Products");
                Console.WriteLine("3. Update Product Price");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice (1/2/3/4/5): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateProduct(db);
                            break;
                        case 2:
                            ReadProducts(db);
                            break;
                        case 3:
                            UpdateProductPrice(db);
                            break;
                        case 4:
                            DeleteProduct(db);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("\n");
            }
        }

        // Orders Table
        static void OrdersMenu(AdvancedDBEntities db)
        {
            while (true)
            {
                Console.WriteLine("Orders Table:");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Read Orders");
                Console.WriteLine("3. Update Order Discount");
                Console.WriteLine("4. Delete Order");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice (1/2/3/4/5): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateOrder(db);
                            break;
                        case 2:
                            ReadOrders(db);
                            break;
                        case 3:
                            UpdateOrderDiscount(db);
                            break;
                        case 4:
                            DeleteOrder(db);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("\n");
            }
        }

//CRUD #1 - Employee Table
        static void CreateEmployee(AdvancedDBEntities db)
        {
            Console.Write("Enter First Name: ");
            string fName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lName = Console.ReadLine();

            Console.Write("Enter Salary: ");
            if (double.TryParse(Console.ReadLine(), out double salary))
            {
                Console.Write("Enter Birth Date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    var newEmployee = new Employee
                    {
                        FName = fName,
                        LName = lName,
                        Salary = salary,
                        BirthDate = birthDate
                    };
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    Console.WriteLine("Employee created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Employee creation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid salary. Employee creation failed.");
            }
        }

    static void ReadEmployees(AdvancedDBEntities db)
        {
            var employees = db.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.EmpId}, Name: {employee.FName} {employee.LName}, Salary: {employee.Salary}, Birth Date: {employee.BirthDate}");
            }
        }
    
    static void UpdateEmployeeSalary(AdvancedDBEntities db)
        {
            Console.Write("Enter Employee ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int empId))
            {
                var employeeToUpdate = db.Employees.FirstOrDefault(e => e.EmpId == empId);
                if (employeeToUpdate != null)
                {
                    Console.Write("Enter New Salary: ");
                    if (double.TryParse(Console.ReadLine(), out double newSalary))
                    {
                        employeeToUpdate.Salary = newSalary;
                        db.SaveChanges();
                        Console.WriteLine("Employee salary updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid salary. Update operation failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Employee not found. Update operation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Employee ID.");
            }

        }

        static void DeleteEmployee(AdvancedDBEntities db)
        {
            Console.Write("Enter Employee ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int empId))
            {
                var employeeToDelete = db.Employees.FirstOrDefault(e => e.EmpId == empId);
                if (employeeToDelete != null)
                {
                    db.Employees.Remove(employeeToDelete);
                    db.SaveChanges();
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found. Deletion operation failed");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Employee ID.");
            }
        }

        //CRUD #2 - Products Table
        static void CreateProduct(AdvancedDBEntities db)
        {
            Console.Write("Enter Product Name: ");
            string pName = Console.ReadLine();

            Console.Write("Enter Product Description: ");
            string pDescription = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal pPrice))
            {
                Console.Write("Enter Product Release Date (yyyy-MM-dd HH:mm:ss): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime pReleaseDate))
                {
                    var newProduct = new Product
                    {
                        PName = pName,
                        PDescription = pDescription,
                        PPrice = pPrice,
                        PReleaseDate = pReleaseDate
                    };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    Console.WriteLine("Product created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Product creation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid price. Product creation failed.");
            }
        }

        static void ReadProducts(AdvancedDBEntities db)
        {
            var products = db.Products.ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.PId}, Name: {product.PName}, Description: {product.PDescription}, Price: {product.PPrice}, Release Date: {product.PReleaseDate}");
            }
        }

        static void UpdateProductPrice(AdvancedDBEntities db)
        {
            Console.Write("Enter Product ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int pId))
            {
                var productToUpdate = db.Products.FirstOrDefault(p => p.PId == pId);
                if (productToUpdate != null)
                {
                    Console.Write("Enter New Price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                    {
                        productToUpdate.PPrice = newPrice;
                        db.SaveChanges();
                        Console.WriteLine("Product price updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Update operation failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found. Update operation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Product ID.");
            }
        }

        static void DeleteProduct(AdvancedDBEntities db)
        {
            Console.Write("Enter Product ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int pId))
            {
                var productToDelete = db.Products.FirstOrDefault(p => p.PId == pId);
                if (productToDelete != null)
                {
                    db.Products.Remove(productToDelete);
                    db.SaveChanges();
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found. Deletion operation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Product ID.");
            }
        }

        // CRUD #3 - Orders Table
        static void CreateOrder(AdvancedDBEntities db)
        {
            Console.Write("Enter Order Date (yyyy-MM-dd HH:mm:ss): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime orderDate))
            {
                Console.Write("Enter Order Quantity: ");
                if (short.TryParse(Console.ReadLine(), out short oQuantity))
                {
                    Console.Write("Enter Order Discount: ");
                    if (float.TryParse(Console.ReadLine(), out float oDiscount))
                    {
                        Console.Write("Is Order Shipped? (1 for Yes, 0 for No): ");
                        if (byte.TryParse(Console.ReadLine(), out byte oIsShipped))
                        {
                            var newOrder = new Order
                            {
                                OrderDate = orderDate,
                                OQuantity = oQuantity,
                                ODiscount = oDiscount,
                                OIsShipped = (oIsShipped == 1)
                            };
                            db.Orders.Add(newOrder);
                            db.SaveChanges();
                            Console.WriteLine("Order created successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for 'Is Order Shipped?'. Order creation failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for discount. Order creation failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for quantity. Order creation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Order creation failed.");
            }
        }

        static void ReadOrders(AdvancedDBEntities db)
        {
            var orders = db.Orders.ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OId}, Date: {order.OrderDate}, Quantity: {order.OQuantity}, Discount: {order.ODiscount}, Shipped: {order.OIsShipped}");
            }
        }

        static void UpdateOrderDiscount(AdvancedDBEntities db)
        {
            Console.Write("Enter Order ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int oId))
            {
                var orderToUpdate = db.Orders.FirstOrDefault(o => o.OId == oId);
                if (orderToUpdate != null)
                {
                    Console.Write("Enter New Discount: ");
                    if (float.TryParse(Console.ReadLine(), out float newDiscount))
                    {
                        orderToUpdate.ODiscount = newDiscount;
                        db.SaveChanges();
                        Console.WriteLine("Order discount updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid discount. Update operation failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Order not found. Update operation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Order ID.");
            }
        }

    static void DeleteOrder(AdvancedDBEntities db)
        {
            Console.Write("Enter Order ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int oId))
            {
                var orderToDelete = db.Orders.FirstOrDefault(o => o.OId == oId);
                if (orderToDelete != null)
                {
                    db.Orders.Remove(orderToDelete);
                    db.SaveChanges();
                    Console.WriteLine("Order deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Order not found. Deletion operation failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Order ID.");
            }
        }
    }
}
