Feature: End To End Tests - Posts and comments
         As a JSONPlaceholder user
		 I want to be able to work on the posts and comments
		 So that I can see,edit and delete my posts and comments

Scenario: E2E Posts and comments
          ## GET request to posts endpoint
          Given that I can access JSONPlaceholder 'posts' endpoint
		  ##verifying status code is 200
		  And I get status code '200'
		  ##Creating 3 posts
          When I send a POST request to the below end point :
          | endPoint | referenceData                             |
          | posts    | userId:1,title:Test_1,body:Post Testing 1 |
          | posts    | userId:1,title:Test_2,body:Post Testing 2 |
          | posts    | userId:1,title:Test_3,body:Post Testing 3 |
		  ##verifying that the posts are created by using GET request
		  ##This step failed as new posts were not there in the GET response.(However POST request was successful with 201 status code and new id which is '101')
		  ##All the below steps will fail as newly created posts and post id's are missing
          Then new 'posts' are created
		  | title  |
		  | Test_1 |
		  | Test_2 |
		  | Test_3 |
		  ##Editing newly created posts
          When I send a PUT request to the below end point :
          | endPoint | referenceData                                       |
          | posts    | Test_1,userId:1,title:updated 1,body:Post Updated 1 |
          | posts    | Test_2,userId:1,title:updated 2,body:Post Updated 2 |
          | posts    | Test_3,userId:1,title:updated 3,body:Post Updated 3 |
		  ##verifying posts are updated
          Then 'posts' are updated
		  | post   | title     | body           |
		  | Test_1 | updated 1 | Post Updated 1 |
		  | Test_2 | updated 2 | Post Updated 2 |
		  | Test_3 | updated 3 | Post Updated 3 |
		  ##Adding new comments to newly created posts posts
		  When I send a POST request to the below end point :
		  | endPoint | referenceData                                                                |
		  | comments | postid:Test_1,name:comment_1,email:comment@gmail.com_1,body:comments Testing |
		  | comments | postid:Test_2,name:comment_2,email:comment@gmail.com_2,body:comments Testing |
		  | comments | postid:Test_3,name:comment_3,email:comment@gmail.com_3,body:comments Testing |
		  ##verifying comments are created
		  Then new 'comments' are created
		  | name      |
		  | comment_1 |
		  | comment_2 |
		  | comment_3 |
		  ##Editing comments
          When I send a PUT request to the below end point :
          | endPoint | referenceData                    |
          | comments | comment_1,body:comment updated 1 |
          | comments | comment_2,body:comment updated 2 |
          | comments | comment_3,body:comment updated 3 |
		  ##Verifying comments are edited
		  Then 'comments' are updated
		  | comments  | body              |
		  | comment_1 | comment updated 1 |
		  | comment_2 | comment updated 2 |
		  | comment_3 | comment updated 3 |