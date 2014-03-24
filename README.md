AwfulVideoStore
===============

Refactoring workshop. Practice example on how to manage legacy code and start writing unit tests. Theory is here - http://www.slideshare.net/SmartStepGroup/ss-32655053

##### Task #1. Extract and Override Factory Method
 - Move everything related to Session and TextBoxes in Login Page to new method. Write tests on authorization
 - Do the same for SellingReport Page. Write tests that only admin can see report

##### Task #2. Dependency Injection
 - Introduce ISession and use it in Login where authorize user. You can just make a simple static field instead of intoducing any IoC frameworks here
 - Use ISession in Default Page when loading movie list
 - Introduce new interface which will declare loading movies from XML. Use it in Default Page instead of direct loading

##### Task #3. SPROUT Method
 - Do not include 18+ rating movies into Selling Report
 - In Default Page for user continue filter movies with 14+ rating but at the same time display all 'New Release' movies. 
 - Sort movies displaying for admin (DefaultMovieService) by price
 

##### Task #4. Wrap method
 - Include into Selling Report Top 5 movies for best selling category
