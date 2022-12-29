# WordFinder
This repository finds a word  in a 2D character array (Horizontal or Vertical).

## Assumptions
The Following are the assumptions made and also in line with the requirements. 

1. Words can be searched in a given matrix either from Left to right or Top to Bottom. There is no support for diagonal or bottom to top or right to left patterns in this project.


2. The type of character matrix only supports a square matrix.


3. The character matrix only supports (A-Z or a-z). It does not support any other Ascii characters.


4. The Input strings can only be between 3 and 10 characters.


5. The Inputs are read from a file into a string array. So here the assumption is each string lenght is the same as the other string lenghts . Also the string lenght is same as the number of strings in the List of strings. 

6. The input strings even if it contains non-alphabet characters , it would go into the notFoundString bucket in the response.


## Inputs 

1. There is an input text file having the character array.

2. There is another input text file having the list of Input Strings.


## Outputs

1. It displays the List of Strings those are found as well as the list of strings those are not found along with the Error Message.

## Project Structure

The Project Structure follows the clean architecture pattern. The main console application calls the services. All the projects are dependent on the Core layer that holds the models.

There is another project for Unit Tests testing the services.


1. Main project is a console application.

2. The business logic is part of the WordFinder.Service Layer. Services project has Validation and Processing logic to it.

3. The core project has the models those are referenced in another projects. It has the input and output models used in the project.

4. The tests project tests the core business logic for all scenarios for validation as well as processing.


## Improvements

The above project considers word finder in top - bottom or left to right approach.

Next version would be to support diagonal traversal , bottom-top and right to left approaches.

## Conclusion

Thank You for giving me an opportunity to work on this project. I learnt a lot during the course of the project and I always like to keep learning.

Thank You !!!

