# Playground

I wanted a low stakes repository to put a bunch of code to try crap that I don't know if I wanted to keep or throw.

New languages, new tools, design ideas for problems. All can go in here.

# Experiments

## FSharp

### Paket

I have not used Paket as a dependency management tool before. I want to explore and become more familiar with it by using it to manage all dependencies in the F# modules of this playground.

### Kleisli Composition

I'm leveraging some ideas I learned from the Giraffe HTTP Routing library for F# in an attempt to design a composition-focused configuration for functionality in a warehouse management system.

By creating a common type and following the HttpHandler/HttpFunc/HttpFuncResult examples from Giraffe, we are able to compose together smaller functions to build up a bigger workflow. Things such as routing, validation, and post-event side effects can all be built into a single flow based on composition.