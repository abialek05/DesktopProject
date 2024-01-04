# Desktop application written in C#.
Functions:
- Add/Delete/View clients, products, invoices, etc.
- Sort and filter by chosen value.
- Open new windows using keyboard shortcuts.
- Choose types/categories/etc. from the list in new window for easier navigation 

![image](https://github.com/abialek05/DesktopProject/assets/152793437/05955862-4dfb-439d-a9d2-e6eec0434442)
![image](https://github.com/abialek05/DesktopProject/assets/152793437/e1939466-3b04-4735-b7b7-4592ae5cd0b1)
![image](https://github.com/abialek05/DesktopProject/assets/152793437/8447ebeb-2138-49a6-9a01-3c0d7133414e)
![image](https://github.com/abialek05/DesktopProject/assets/152793437/75289fdd-08f0-4c5a-8c6b-8eb01560c426)

To run the application, you need to create SQL database from the edmx Model. Below instruction refers to Visual Studio 2022.
1. Go to Models>Entities>InvoicesModel.edmx
2. Right click on an empty space on the Entity Designer and choose select Generate Database from Model.
4. On the dialog box, click the New Connection button or select an existing connection button from the drop-down list to provide a database connection.
5. Click next and then finish once available.
You may need to install any necessary packages to perform the above.
