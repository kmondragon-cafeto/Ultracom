## Introduction
You need to implement three methods at SeleniumTask.SeleniumExecutor class that should use a Selenium WebDriver to pass a sudoku-like login mechanism. The page is located in the `SeleniumTask/resources/__files/index.html`. You can assume that the page has been already loaded by the driver. 

## Problem Statement

1. **SeleniumTask.SeleniumExecutor.FillAllFields** - You need to put numbers in all writable text boxes. Below the text-field, there is a number that you need to write to pass login successfully:   
   ![FillAllFields](readmeFiles/1FillAllFields.PNG?raw=true "FillAllFields")

2. **SeleniumTask.SeleniumExecutor.ClickLogin** -  Click the `Log in` button.

3. **SeleniumTask.SeleniumExecutor.GetCodeFromCodePage** -  Get the text from `p` with ID `loggedIn`. **Don't return hardcoded strings!**


