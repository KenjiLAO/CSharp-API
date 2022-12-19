
In the appsettings.json, make sure to have : 

"ConnectionStrings": {
    "DefaultConnection": "server = localhost; user = root ; password = ; database = name_your_database;"
  }

Install XAMPP and launch the application :

![image](https://user-images.githubusercontent.com/116066245/208503181-1486454f-5a28-4d6d-93ec-af0b112fb11e.png)

Press Start on the Apache and MySQL section.

Go to this link to see the database : http://localhost/phpmyadmin/index.php

Go to "view in click to "Terminal"

![image](https://user-images.githubusercontent.com/116066245/208503611-9a7bac96-43c5-440c-aa54-346067c2e4f8.png)

Launch the API in the terminal with dotnet run


Before creating a character, you have to create :
- a new region
- a new vision
- a new weapon

Then you may be able to create, modify, check and delete the characters. ( When you get a character, the region, vision and weapon sections are "null", work in proress)
