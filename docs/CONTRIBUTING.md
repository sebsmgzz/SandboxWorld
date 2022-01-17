Contributing
============
First off, thanks for taking the time to contribute!

The following is a set of guidelines for contributing to the project and its packages.
These are mostly guidelines, not rules. 
Use your best judgment, and feel free to propose changes to this document in a pull request.

Reporting bugs
--------------
This section guides you through submitting a bug report. 
Following these guidelines helps maintainers and the community understand your report, reproduce the behavior, and find related reports.

Before creating bug reports, please check the existing list as you might find out that you don't need to create one. 
When you are creating a bug report, please include as many details as possible. 
Fill out the required template, the information it asks for helps us resolve issues faster.

### Before submitting a bug report
- Check the discussions for a list of common questions and problems.
- Determine which repository the problem should be reported in.
- Perform a cursory search to see if the problem has already been reported. If it has and the issue is still open, add a comment to the existing issue instead of opening a new one.

### How do I submit a (good) bug report?
Bugs are tracked as issues. 
After you've determined which repository your bug is related to, create an issue on that repository and provide the following information by filling in the template.

Explain the problem and include additional details to help maintainers reproduce the problem:
- Use a clear and descriptive title for the issue to identify the problem.
- Describe the exact steps which reproduce the problem in as many details as possible.
- Provide specific examples to demonstrate the steps.
- Describe the behavior you observed after following the steps and point out what exactly is the problem with that behavior.
- Explain which behavior you expected to see instead and why.
- Include screenshots and animated GIFs which show you following the described steps and clearly demonstrate the problem.
- If you're reporting a crash, include a crash report with a stack trace from the operating system.
- If the problem is related to performance or memory, include a CPU profile capture with your report.
- If the problem wasn't triggered by a specific action, describe what you were doing before the problem happened and share more information using the guidelines below.

Provide more context by answering these questions:
- Can you reproduce the problem in safe mode?
- Did the problem start happening recently (e.g. after updating to a new version) or was this always a problem?
- Can you reproduce the problem in an older version?
- Can you reliably reproduce the issue? If not, provide details about how often the problem happens and under which conditions it normally happens.

Styleguides
-----------

### Code styleguide
- End the file with a line break. It makes it easier to append new data from the cli.
- Follow the most common practices accordingly for each language.

### Versioning
We follow a basic [semantic versioning](https://semver.org/) naming convention.
Where X.Y.Z represents a version number:
- X is the MAYOR version, usually migrations and breaking business logic changes
- Y is the MINOR version, features additions
- Z is the PATCH version, bug fixes, refactoring, etc

### Git commit messages styleguide
- Use the imperative mood forsubjects (If applied, this commit will [commit-message-here])
- Limit the first line to 72 characters or less
- Reference issues and pull requests liberally after the first line
- Consider starting the commit message with an applicable prefix (see below)
- Whenever possible include the issue id in parenthesis after the prefix, (i.e `fix(42): Adds missing semicolon`)

| Prefix    | Description |
| :-        | :-          |
| `docs:`   | Adding or updating documentation
| `fix:`    | Fixing a bug, most likely related to an issue
| `feat:`   | Feature addition, usually integrated as branch merges
| `chore:`  | Regular code maintenance, a part of the implementation towards a feature as a whole
| `refact:` | Refactoring code, renaming variables, moving classes into multiple files, etc
| `style:`  | Changes to comply with style guidelines. Indentation changes, brackets alignment, etc
| `test:`   | Anything related to testing

### Git branch naming styleguide
There are 6 types of branches.

- **Production** - One to rule them all. Named `main` (aka `master`), a single branch considered the root of the repo. This branch will go into production. Never push directly to this branch, except when initially setting up a repository.
- **Release** - These are the branches that integrate the features as a whole. While a release should be fully documented before hand, this is not always possible, therefore only documentation commits are allowed here. For bugfixes, you can checkout a `hfix` branch from here and merge it with as a fix. This branch is not checked out from `development` branches only. And do not accept new featuers.
- **Hotfix** - These branches are unexpected bug fixes that skip the entire workflow due to their relationship to the production environment. The naming convention is `hfix\X` where `X` is the issue id of the bug (if any). Multiple hot fixes branches can exists but the recomendation is to have one at a time (depends on each individual situation). Check them out from a `release`  branch and merge them directly to it. These fixes require a patch version increment. (i.e. 1.0.0 changes to 1.0.1)
- **Develop** - These branch is related to the integration phase of the code. Only one development branch shall exist and any given time. If different development versions are being worked in parallel, append the version number to each branch separately. The initial development branch shall be pulled from `main` since there is no initial release yet. Any further development branch shall be pulled from a previous `release` declaring the start of a work stage. In order to merge this branches, checkout a `release` branch from the `develop` and then follow the `release` branch workflow. Allowed commits include bug fixes and refactoring, style and documentation. Any other type of commit shall come from a feature branch.
- **Feature** - Here is where the magic happens. Anytype of commits are allowed here. Branch naming is `feat\X` where `X` is the issue number of the feature. However, if several developers are working on an individual feature, it is recommended to split those branches into separate branches by appending the name of the developer to them. Once these branch merge into a `develop` branch, delete them.
- **Experimental** - These branches are completly meant for breaking up things. Feel free to use them to mess around and do research for specific features. Do **NOT** ever merge this branches since they are meant to be cause breaking changes to the existing code base.

| Branch       | Name        | Allowed commits                  | Checkout from       | Merge into |
| :-           | :-          | :-                               | :-                  | :-         |
| Production   | `main`      | None                             | None                | None
| Release      | `release\X` | `docs`                           | `develop`           | `main`
| Hotfix       | `hfix\X`    | `fix`                            | `release\X`         | `release\X`
| Develop      | `develop`   | `fix`, `docs`, `style`, `refact` | `main`, `release`   | None
| Feature      | `feat\X`    | Any                              | `develop`           | `develop`
| Experimental | `exp\X`     | Any                              | Any                 | None

### Documentation styleguide
Use markdown whenever possible:
- Use a single `h1` header per documentation file.
- Preffer the use of `=` and `--` over `#` and `##` for `h1` and `h2` respectfully.
- Preffer the use of `-` over `*` and `+` for unordered lists.
- Use ` ``` ` followed by the code language for code blocks.

#### Highlights
Use `NOTE`, `WARNING`, or `IMPORTANT` to highlight statements.
Always prepend them with a `>` to denote the highlight.
For example:
```md
> #### NOTE
> This is a note
```

Labels
------

#### Generic labels
Use this labels for simply tagging and categorizing of issues and pull/merge requests.
Feel free to add as required, since these are dictated by the project itself and
the team's workflow.

| Color   | Label | Description |
| :-      | :-    | :-          |
| #9F2B00 | `bug` | Indicates an unexpected problem or unintended behavior
| #489C17 | `enhancement` | Indicates a new feature or refactoring
| #0000FF | `documentation` | Indicates a need for improvements or additions to documentation
| #A91B60 | `duplicate` | Indicates similar issues, pull/merge requests, or discussions already exist
| #52688F | `question` | Indicates that an issue, pull/merge request, or discussion needs more information
| #523A28 | `invalid` | Indicates that an issue, pull/merge request, or discussion is no longer relevant

#### Priority labels
Uses the Eisenhower Decision Principle.
This labels must be provided in pairs, always *importance* + *urgency*.
The *importance* determines how likely is the issue to affect long-term goals.
The *urgency* determines how much of a fast response is required.
The resulting combination dictates the action to take with the issue:
- `priority::importance::high` + `priority::urgency::high` = Must be done asap
- `priority::importance::high` + `priority::urgency::low` = Schedule them to be done in a calm and proper matter
- `priority::importance::low` + `priority::urgency::high` = Delegate to someone that can approach the issue asap
- `priority::importance::low` + `priority::urgency::low` = Won't do

| Color   | Label | Description |
| :-      | :-    | :-          |
| #C85250 | `priority::importance::high` | Issue is likely to block/affect future work.
| #F7BEC0 | `priority::importance::low` | Issue won't affect future work in a negative way. 
| #C85250 | `priority::urgency::high` | Issue has a close deadline, or asap attention.
| #F7BEC0 | `priority::urgency::low` | Issue deadline is far away.

#### Work level labels
Based of the Cynefin framework. 
This label dictates the level of effor for a specific issue.
The more *disorder* the label indicates, the more knowledge is required to solve it.
Project managers and architects as well as the author of the issue should be able to 
work together to break down highly disorderd issues into smaller ones with a specific
target in it. The amount of breakdown needed is directly dependand on the experience
of the technical team working in the project. For example, a senior developer might
be able to take *complex* tasks, whereas a junior developer will require the task 
to be broken down into *simple* tasks in order for them to accomplish it correctly.

| Color   | Label | Description |
| :-      | :-    | :-          |
| #E6E6FA | `work::simple` | Issue consists of "known knowns". The relationship between cause and effect is clear: if you do X, expect Y.
| #B1B1B1 | `work::complicated` | Issue consists of "known unknowns". The relationship between cause and effect requires analysis or expertise.
| #747474 | `work::complex` | Issue consists of "unknown unknowns". The relationship between cause and effect can only be deduced in retrospect, and there are no right answers.
| #444444 | `work::chaotic` | Issue is "too confusing to wait for a knowledge-based response". The relationship between cause and effect are unclear.
| #0A0708 | `work::disorder` | Issue with no clarity of which kind of consistency or work applies. 

#### Status labels
Based of the basic Kanban framework. 
This label dictates the status of a current issue.
Ultimately issues are open or closed, but there are also intermediate states that 
are required to be labeled for better tracking. Feel free to add as many as you need,
since this depends on the available environments for the project, and the project itself.

| Color   | Label | Description |
| :-      | :-    | :-          |
| #00B140 | `status::ongoing` | Issue is moving towards completion as there is work being made to solve them.
| #FBB80F | `status::testing` | Issue is considered complete but lack quality assurance and approvements.
| #DC143C | `status::blocked` | Issue is blocked and unable to work on due to a different issue going on.
