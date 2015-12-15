# price-calculation-exercise
Price calculation exercise.

## Notes
- I used static products to mimic a product data source for simplicity
- I committed more frequently that I ordinarily would to demonstrate progress
- I chose to seperate out the offer calculation as the basket had multiple responsibilities - calculating product total and applying offers
- I could have chosen to use Chicago style TDD when seperating out the offer classes - leaving the tests unchanged and essentially performing an integration test between the basket and the offer - but I chose to use a London style approach meaning mocks were used in the basket tests, asserting only that the injected offers were called and the offer-specific tests moved out to their own classes. For more information see: http://programmers.stackexchange.com/a/123672/24948 
- There are some similarities between the BreadOffer and MilkOffer class - these could be made more generic and the similarities pulled into a super class with a template method for matching criteria and supplying the required discount, but I didn't want to overengineer the solution without more context