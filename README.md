# Mocking frameworks or manual mocks?
###This is the code used during SoCraTes Italy 2018

Take a look at the stream of commits, they should make my point clearer.
The main problem is the lack of feedback when I make changes to add/modify a behavior. In the GOOS book the use of a mocking framework is paired with E2E tests, which I rarely see around because they're costly.
Furthermore, mocking frameworks are a sharp knife and I've seen some horrible usages around. 

# These are some of the concerns expressed during the presentation
Q: But without a mocking framework you can't do outside-in TDD!
A: Nope, not related. You can still do outside-in using manual mocks, I do!

Q: The test using manual mocks is more opaque
A: I respectfully disagree. Tests should not reveal implementation details but express an observable behavior, that's what makes refactoring sustainable

Q: The tests that reuse a manual mocks are a little more coupled, meaning that if you make a mistake in the "InMemory..." fake implementation a bunch of tests will break
A: Yes, that's true. That's a trade-off I'm willing to accept because it hasn't been a problem so far...

Do you have a question or observation to make? Post an issue and I'll try to answer