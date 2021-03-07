## **DB Corp**

Evaluation project for **DB Corp** Company

- [Specification](documents/DBCorp \- Teste de recrutamento.pdf)

- [References used](documents/references.md)
  
  
-----

This implementation is a console application with parameters passed through the command line. To know how to use it, it must be executed without any parameter or with '--help' or '-h' as the first parameter, resulting in the explanation shown in 'Image 1'.  

 `
    > ./dbc-vm --help
 `

 ![Image 1](screenshots/image-01.png)  
 #### (Image 1) 
  
  
    
 ### Examples of use

 Obtendo a lista de produtos

 `

    > ./dbc-vm --products

 `

 ![Image 2](screenshots/image-02.png)  
 ##### (Image 2) 
   
   

Ordering the item with index 1 (Cappuccino) using only one dollar coins in sufficient quantity, resulting only in the return of the calculated change.  

 `

    > ./dbc-vm --order 1 100:5

 `
 ![Image 2](screenshots/image-03.png)  
 ##### (Image 3) 
 

