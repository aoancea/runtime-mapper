# Contributing to Runtime Mapper

We would love for you to contribute to Runtime Mapper and help make it even better than it is
today! As a contributor, here are the guidelines we would like you to follow:

 - [Issues and Bugs](#found-a-bug)
 - [Feature Requests](#missing-a-feature)
 - [Submission Guidelines](#submission-guidelines)
 - [Coding Rules](#coding-rules)
 - [Commit Message Guidelines](#commit-message-guidelines)

## Found a Bug?
If you find a bug in the source code, you can help us by
[submitting an issue](https://github.com/aoancea/runtime-mapper/issues) to our [GitHub Repository](https://github.com/aoancea/runtime-mapper). Even better, you can
[submit a Pull Request](https://github.com/aoancea/runtime-mapper/pulls) with a fix.

## Missing a Feature?
You can *request* a new feature by [submitting an issue](https://github.com/aoancea/runtime-mapper/issues) to our GitHub
Repository. If you would like to *implement* a new feature, please submit an issue with
a proposal for your work first, to be sure that we can use it.

## Submission Guidelines

### Submitting an Issue

Before you submit an issue, please search the issue tracker, maybe an issue for your problem already exists and the discussion might inform you of workarounds readily available.


## Coding Rules
To ensure consistency throughout the source code, keep these rules in mind as you are working:

* All features or bug fixes **must be tested** by one or more specs (unit-tests).

## Commit Message Guidelines

We have very precise rules over how our git commit messages can be formatted.  This leads to **more
readable messages** that are easy to follow when looking through the **project history**.

### Type
Must be one of the following:

* **build**: Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
* **ci**: Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
* **docs**: Documentation only changes
* **feat**: A new feature
* **fix**: A bug fix
* **perf**: A code change that improves performance
* **refactor**: A code change that neither fixes a bug nor adds a feature
* **style**: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
* **test**: Adding missing tests or correcting existing tests

### Scope
The scope should be the name of the module affected (as perceived by person reading changelog generated from commit messages).

The following is the list of supported scopes:

* **mapper**
* **mapper-string**
* **mapper-value-type**
* **mapper-collection**
* **mapper-dictionary**
* **mapper-object**


### Subject
The subject contains succinct description of the change:

* use the imperative, present tense: "change" not "changed" nor "changes"
* don't capitalize first letter
* no dot (.) at the end

### Body
Just as in the **subject**, use the imperative, present tense: "change" not "changed" nor "changes".
The body should include the motivation for the change and contrast this with previous behavior.
