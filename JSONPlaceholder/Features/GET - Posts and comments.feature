Feature: GET - Posts and comments
	As a JSONPlaceholeder use
	I want to see posts and comments
	So that I can check details

Scenario Outline: Get the details of posts
          ## GET request to posts endpoint
          Given that I can access JSONPlaceholder 'posts' endpoint
		  ##verifying status code is 200
		  And I get status code '200'
		  ## GET Request to individual posts
		  When I send a GET request to <endpoint> with <parameter>
		  Then I get UserID as <userId>
		  And I get ID as <id>
		  And I get Title as <title>	
Examples: 
 | endpoint | parameter | userId | id | title                                                                      |
 | posts    | 1         | 1      | 1  | sunt aut facere repellat provident occaecati excepturi optio reprehenderit |
 | posts    | 2         | 1      | 2  | qui est esse                                                               |
 | posts    | 3         | 1      | 3  | ea molestias quasi exercitationem repellat qui ipsa sit aut                |

 
 Scenario Outline: Get the details of comments
          ## GET request to posts endpoint
          Given that I can access JSONPlaceholder 'comments' endpoint
		  ##verifying status code is 200
		  And I get status code '200'
		  ## GET Request to individual comments
		  When I send a GET request to <endpoint> with <parameter>
		  Then I get postId as <postId>
		  And I get ID as <id>
		  And I get name as <name>
		  And I get email as <email>
Examples: 
 | endpoint | parameter | postId | id | name                                      | email                  |
 | comments | 1         | 1      | 1  | id labore ex et quam laborum              | Eliseo@gardner.biz     |
 | comments | 2         | 1      | 2  | quo vero reiciendis velit similique earum | Jayne_Kuhic@sydney.com |
 | comments | 3         | 1      | 3  | odio adipisci rerum aut animi             | Nikita@garfield.biz    |
 
 
 Scenario Outline: Get all comments of post 1
          ## GET request to posts endpoint
          Given that I can access JSONPlaceholder 'comments' endpoint
		  ##verifying status code is 200
		  And I get status code '200'
		  ## GET Request to posts/1/comments
		  When I send a GET request to see all the comments of post <1>
		  Then I get postId as <postId>
		  And I get ID as <id>
		  And I get name as <name>		
Examples: 
 | postId | id | name                                      |
 | 1      | 1  | id labore ex et quam laborum              |
 | 1      | 2  | quo vero reiciendis velit similique earum |
 | 1      | 3  | odio adipisci rerum aut animi             |
 | 1      | 4  | alias odio sit                            |
 | 1      | 5  | vero eaque aliquid doloribus et culpa     |


Scenario: Comments post 1 should not contain comments of other posts
          ## GET request to posts endpoint
          Given that I can access JSONPlaceholder 'comments' endpoint
		  ##verifying status code is 200
		  And I get status code '200'
		  ## GET Request to posts/1/comments
		  When I send a GET request to see all the comments of post <1>
		  Then I should not see any comments of other posts